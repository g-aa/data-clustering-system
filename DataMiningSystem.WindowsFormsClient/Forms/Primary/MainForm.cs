using DataMiningSystem.ClientLogic;
using DataMiningSystem.ClientLogic.Handlers;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;
using DataMiningSystem.WindowsFormsClient.Forms.DataSetGenerator;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMiningSystem.WindowsFormsClient.Forms.Primary
{
    public partial class MainForm : Form
    {
        private WorkInfo<TextBox> m_workInfo;
        
        private ClusteringOptions m_options;
        private IMathSet m_mathSet;
        private ClusteringHandler  m_clusteringHandler;
        private ClusteringResult m_cResult;

        private ClusteringResRenderHandler m_cResRenderHandler;

        private BackgroundWorker m_bgw_toCluster;

        public MainForm()
        {
            this.InitializeComponent();

            // настройка лога:
            this.m_workInfo = new WorkInfo<TextBox>(this.m_tbx_log);
            this.m_workInfo.SettingOutputObject += (TextBox tbx, String s) => { tbx.Text = s; };

            this.m_clusteringHandler = new ClusteringHandler();

            this.m_cResRenderHandler = new ClusteringResRenderHandler(this.m_pbx_clustersBinding);
            this.m_pbx_clustersBinding.Image = this.m_cResRenderHandler.GetBitmap();

            // настройка опций кластеризации:
            this.m_options = ClusteringOptions.Default;
            // количество кластеров:
            this.m_tbx_clastersCount.Text = this.m_options.ClusterCount.ToString();
            // максимальное число итераций:
            this.m_tbx_maxIter.Text = this.m_options.MaxIterations.ToString();
            // способ инициализации:
            this.m_cbx_initType.Items.AddRange(Enum.GetNames(typeof(InitializationType)));
            this.m_cbx_initType.SelectedIndex = (int)this.m_options.Initialization;
            // метрика:
            this.m_cbx_distance.Items.AddRange(Enum.GetNames(typeof(DistanceMetricType)));
            this.m_cbx_distance.SelectedIndex = (int)this.m_options.Distance;
            // тип алгоритма (однопоточный, многопоточный):
            this.m_cbx_algoritmType.Items.AddRange(Enum.GetNames(typeof(ModeType)));
            this.m_cbx_algoritmType.SelectedIndex = (int)this.m_options.Mode;
            // алгоритм:
            this.m_cbx_algoritm.Items.AddRange(Enum.GetNames(typeof(AlgorithmType)));
            this.m_cbx_algoritm.SelectedIndex = (int)this.m_clusteringHandler.Algorithm;                                               
            
            // настройка кнопок:
            this.m_btn_loadDataSet.Click += this.m_btn_loadDataSet_Click;
            this.m_btn_clustering.Click += this.m_btn_toCluster_Click;
            this.m_btn_paintClasses.Click += this.m_btn_paintClasses_Click;
            this.m_btn_paintClusters.Click += this.m_btn_paintClusters_Click;
            this.m_btn_generator.Click += this.m_btn_generator_Click;
            this.m_btn_datasetInfo.Click += this.m_btn_datasetInfo_Click;

            // фоновый обработчик кластеризации:
            this.m_bgw_toCluster = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            this.m_bgw_toCluster.DoWork += this.m_bgw_toCluster_DoWork;
            this.m_bgw_toCluster.ProgressChanged += this.m_bgw_toCluster_ProgressChanged;
            this.m_bgw_toCluster.RunWorkerCompleted += this.m_bgw_toCluster_RunWorkerCompleted;
        }

        private void m_btn_datasetInfo_Click(object sender, EventArgs e)
        {
            if (this.m_mathSet != null)
            {
                DataSetInfo info = this.m_mathSet.SetInformation;
                this.m_workInfo.AddInfornation(info.ToString());
            }
            else
            {
                this.m_workInfo.AddWarning("MathSet не загружен");
            }
        }

        private void m_btn_generator_Click(object sender, EventArgs e)
        {
            GeneratorForm gf = new GeneratorForm();
            gf.ShowDialog();
        }

        private void m_btn_loadDataSet_Click(object sender, EventArgs e)
        {
            this.m_workInfo.AddInfornation("выбор подходящего набора данных");
            using (OpenFileDialog fd = new OpenFileDialog() {
                InitialDirectory = @"c:\",
                Filter = "json files (*.json)|*.json|xml files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true })
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(fd.FileName);
                        if (fi.Extension.Equals(".xml"))
                        {
                            var set = DataSetSerializer.LoadFromXmlFile(fd.FileName);
                            this.m_mathSet = DataSetSerializer.SetToIMathSet(set);
                        }
                        else
                        {
                            using (StreamReader sr = new StreamReader(fd.FileName, Encoding.Default))
                            {
                                String jsonString = sr.ReadToEnd();
                                this.m_mathSet = DataSetSerializer.JsonToMathSet(jsonString);
                            }
                        }
                        this.m_workInfo.AddInfornation("набор данных \'" + fi.Name + "\' загружен");
                        this.m_cResRenderHandler.ClearSheet();
                        this.m_pbx_clustersBinding.Image = this.m_cResRenderHandler.GetBitmap();
                        this.UpdateClassesChart();
                    }
                    catch (Exception ex)
                    {
                        this.m_workInfo.AddError(ex.Message);
                    }
                }
                else
                {
                    this.m_workInfo.AddInfornation("операция отменена");
                }
            }
        }

        private void m_btn_toCluster_Click(object sender, EventArgs e)
        {
            try
            {
                // проверка опций кластеризации:
                int clusterCount = int.Parse(this.m_tbx_clastersCount.Text);
                if (clusterCount < 2 || clusterCount > 8)
                {
                    throw new Exception("количество кластеров должно быть не меньше 2 и не больше 8");
                }
                this.m_options.ClusterCount = clusterCount;

                int maxIterations = int.Parse(this.m_tbx_maxIter.Text);
                if (maxIterations < 10 || maxIterations > 500)
                {
                    throw new Exception("число итераций должно быть не меньше 10 и не больше 500");
                }
                this.m_options.MaxIterations = maxIterations;

                this.m_options.Mode = (ModeType)this.m_cbx_algoritmType.SelectedIndex;
                this.m_options.Distance = (DistanceMetricType)this.m_cbx_distance.SelectedIndex;
                this.m_options.Initialization = (InitializationType)this.m_cbx_initType.SelectedIndex;

                this.m_clusteringHandler.Algorithm = (AlgorithmType)this.m_cbx_algoritm.SelectedIndex;

                // проверка датасета:
                if (this.m_mathSet is null)
                {
                    throw new Exception("данные для обработки не были загружены");
                }

                // запуск на выполнение:
                this.m_bgw_toCluster.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
            }
        }


        private void m_bgw_toCluster_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.m_workInfo.AddError(e.Error.Message);
            }
            else
            {
                this.m_cResult = this.m_clusteringHandler.Result;
                String message = String.Format("операция завершена\r\nчисло иттераций - {0}\r\nвремя выполнения - {1} ms", this.m_cResult.IterationCounter, this.m_clusteringHandler.CalculationTime);
                this.m_workInfo.AddInfornation(message);
                this.m_cResRenderHandler.DrawDataset(this.m_cResult);
                this.m_pbx_clustersBinding.Image = this.m_cResRenderHandler.GetBitmap();
            }
        }

        private void m_bgw_toCluster_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    this.m_workInfo.AddInfornation("выполнение кластеризация...");
                    return;
                default:
                    this.m_workInfo.AddInfornation("непредвиденная операция в процессе расчета");
                    return;
            }
        }

        private void m_bgw_toCluster_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is BackgroundWorker worker)
            {
                worker.ReportProgress(0);
                this.m_clusteringHandler.Run(this.m_mathSet, this.m_options);
            }
        }

        private void m_btn_paintClasses_Click(object sender, EventArgs e)
        {    
            this.UpdateClassesChart();
        }

        private void UpdateClassesChart()
        {
            try
            {
                this.m_paintData.Series.Clear(); // удалить все содержимое

                if (this.m_mathSet.CoordinatesCount != 2)
                {
                    throw new ArgumentException("в прямоугольной системе координат можно отобразить только двумерные данные");
                }
                else
                {
                    // построение по классам:
                    List<string> classes = new List<string>();
                    for (int r = 0; r < this.m_mathSet.RowsCount; r++)
                    {
                        if (classes.Contains(this.m_mathSet[r].Class))
                        {
                            int seriesIndex = classes.IndexOf(this.m_mathSet[r].Class);
                            m_paintData.Series[seriesIndex].Points.AddXY(this.m_mathSet[r][0], this.m_mathSet[r][1]);
                        }
                        else
                        {
                            classes.Add(this.m_mathSet[r].Class);
                            m_paintData.Series.Add(string.Format("class: {0}", this.m_mathSet[r].Class));
                            m_paintData.Series[classes.Count - 1].ChartType = SeriesChartType.Point;
                            m_paintData.Series[classes.Count - 1].MarkerSize = 5;
                            m_paintData.Series[classes.Count - 1].Points.AddXY(this.m_mathSet[r][0], this.m_mathSet[r][1]);
                        }
                    }

                    this.m_btn_paintClasses.Enabled = false;
                    this.m_btn_paintClusters.Enabled = true;
                }
            }
            catch (ArgumentException ex)
            {
                this.m_workInfo.AddWarning(ex.Message);
                MessageBox.Show(ex.Message, "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);   
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void m_btn_paintClusters_Click(object sender, EventArgs e)
        {
            this.UpdateClustersChart();
        }

        private void UpdateClustersChart()
        {
            try
            {
                if (this.m_cResult is null)
                {
                    throw new ArgumentException("входные данные не подвергались кластеризации");
                }

                this.m_paintData.Series.Clear(); // удалить все содержимое

                if (this.m_cResult.MathSet.CoordinatesCount != 2)
                {
                    throw new ArgumentException("в прямоугольной системе координат можно отобразить только двумерные данные");
                }
                else
                {
                    // построение по кластерам:
                    List<string> clusters = new List<string>();
                    for (int r = 0; r < this.m_cResult.MathSet.RowsCount; r++)
                    {
                        if (clusters.Contains(this.m_cResult.MathSet[r].Cluster))
                        {
                            int seriesIndex = clusters.IndexOf(this.m_cResult.MathSet[r].Cluster);
                            this.m_paintData.Series[seriesIndex].Points.AddXY(this.m_cResult.MathSet[r][0], this.m_cResult.MathSet[r][1]);
                        }
                        else
                        {
                            clusters.Add(this.m_cResult.MathSet[r].Cluster);
                            this.m_paintData.Series.Add(string.Format("cluster: {0}", this.m_cResult.MathSet[r].Cluster));
                            this.m_paintData.Series[clusters.Count - 1].ChartType = SeriesChartType.Point;
                            this.m_paintData.Series[clusters.Count - 1].MarkerSize = 7;
                            this.m_paintData.Series[clusters.Count - 1].Points.AddXY(this.m_cResult.MathSet[r][0], this.m_cResult.MathSet[r][1]);
                        }
                    }

                    // построение центров кластеризации:
                    for (int c = 0; c < this.m_cResult.Centers.Count; c++)
                    {
                        clusters.Add(this.m_cResult.Centers[c].Cluster);
                        this.m_paintData.Series.Add(string.Format("cluster centor: {0}", this.m_cResult.Centers[c].Cluster));
                        this.m_paintData.Series[clusters.Count - 1].ChartType = SeriesChartType.Point;
                        this.m_paintData.Series[clusters.Count - 1].MarkerSize = 10;
                        this.m_paintData.Series[clusters.Count - 1].Points.AddXY(this.m_cResult.Centers[c][0], this.m_cResult.Centers[c][1]);
                    }

                    this.m_btn_paintClusters.Enabled = false;
                    this.m_btn_paintClasses.Enabled = true;
                }
            }
            catch (ArgumentException ex)
            {
                this.m_workInfo.AddWarning(ex.Message);
                MessageBox.Show(ex.Message, "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
