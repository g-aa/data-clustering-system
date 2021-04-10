using DataMiningSystem.ClientLogic;
using DataMiningSystem.ClientLogic.Handlers;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;
using DataMiningSystem.WindowsFormsClient.Handlers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Forms
{
    public partial class MainForm : Form
    {
        private WorkInfo<TextBox> m_workInfo;
        
        private ClusteringOptions m_options;

        private IMathSet m_mathSet;

        private ClusteringHandler  m_clusteringHandler;

        private DataSetRenderHandler m_renderHandler;

        private BackgroundWorker bgw_toCluster;

        public MainForm()
        {
            this.InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // настройка лога:
            this.m_workInfo = new WorkInfo<TextBox>(this.tbx_log);
            this.m_workInfo.SettingOutputObject += (TextBox tbx, String s) => { tbx.Text = s; };
            // настройка обработчика отрисовки:
            this.m_renderHandler = new DataSetRenderHandler(this.pbx_clustersBinding);
            // настройка кластеризации:
            this.m_clusteringHandler = new ClusteringHandler();
            this.m_options = ClusteringOptions.Default;
            // количество кластеров:
            this.tbx_clustersCount.Text = this.m_options.ClusterCount.ToString();
            // максимальное число итераций:
            this.tbx_maxIteration.Text = this.m_options.MaxIterations.ToString();
            // способ инициализации:
            this.cbx_initType.Items.AddRange(Enum.GetNames(typeof(InitializationType)));
            this.cbx_initType.SelectedIndex = (int)this.m_options.Initialization;
            // метрика:
            this.cbx_distance.Items.AddRange(Enum.GetNames(typeof(DistanceMetricType)));
            this.cbx_distance.SelectedIndex = (int)this.m_options.Distance;
            // тип алгоритма (однопоточный, многопоточный):
            this.cbx_algorithmType.Items.AddRange(Enum.GetNames(typeof(ModeType)));
            this.cbx_algorithmType.SelectedIndex = (int)this.m_options.Mode;
            // алгоритм:
            this.cbx_algoritm.Items.AddRange(Enum.GetNames(typeof(AlgorithmType)));
            this.cbx_algoritm.SelectedIndex = (int)this.m_clusteringHandler.Algorithm;                                               
            
            // настройка кнопок:
            this.btn_clustering.Click += this.Btn_clustering_Click;
            this.btn_create.Click += this.Btn_create_Click;
            this.btn_datasetInfo.Click += this.Btn_datasetInfo_Click;
            this.btn_load.Click += this.Btn_load_Click;
            this.btn_renderClasses.Click += this.Btn_renderClasses_Click;
            this.btn_renderClusters.Click += this.Btn_renderClusters_Click;

            // фоновый обработчик кластеризации:
            this.bgw_toCluster = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            this.bgw_toCluster.DoWork += this.m_bgw_toCluster_DoWork;
            this.bgw_toCluster.ProgressChanged += this.m_bgw_toCluster_ProgressChanged;
            this.bgw_toCluster.RunWorkerCompleted += this.m_bgw_toCluster_RunWorkerCompleted;
        }

        private void Btn_datasetInfo_Click(object sender, EventArgs e)
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

        private void Btn_create_Click(object sender, EventArgs e)
        {
            GeneratorForm gf = new GeneratorForm();
            gf.ShowDialog();
        }

        private void Btn_load_Click(object sender, EventArgs e)
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
                        this.m_renderHandler.AddMathSet(this.m_mathSet);
                        this.RenderClasses();
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

        private void Btn_clustering_Click(object sender, EventArgs e)
        {
            try
            {
                // проверка опций кластеризации:
                this.CheckClusteringOptions();

                // проверка датасета:
                if (this.m_mathSet is null)
                {
                    throw new Exception("данные для обработки не были загружены");
                }

                // запуск на выполнение:
                this.bgw_toCluster.RunWorkerAsync();
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
                string format = "операция завершена\r\nчисло иттераций - {0}\r\nвремя выполнения - {1} ms";
                string message = string.Format(format, this.m_clusteringHandler.Result.IterationCounter, this.m_clusteringHandler.CalculationTime);
                this.m_workInfo.AddInfornation(message);

                this.m_renderHandler.AddClusteringResult(this.m_clusteringHandler.Result);
                this.RenderClusters();
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

        private void Btn_renderClasses_Click(object sender, EventArgs e)
        {
            this.RenderClasses();
        }

        private void Btn_renderClusters_Click(object sender, EventArgs e)
        {
            this.RenderClusters();
        }

        private void CheckClusteringOptions()
        {
            int clusterCount = int.Parse(this.tbx_clustersCount.Text);
            if (clusterCount < 2 || clusterCount > 8)
            {
                throw new Exception("количество кластеров должно быть не меньше 2 и не больше 8");
            }
            this.m_options.ClusterCount = clusterCount;

            int maxIterations = int.Parse(this.tbx_maxIteration.Text);
            if (maxIterations < 10 || maxIterations > 500)
            {
                throw new Exception("число итераций должно быть не меньше 10 и не больше 500");
            }
            this.m_options.MaxIterations = maxIterations;

            this.m_options.Mode = (ModeType)this.cbx_algorithmType.SelectedIndex;
            this.m_options.Distance = (DistanceMetricType)this.cbx_distance.SelectedIndex;
            this.m_options.Initialization = (InitializationType)this.cbx_initType.SelectedIndex;
            this.m_clusteringHandler.Algorithm = (AlgorithmType)this.cbx_algoritm.SelectedIndex;
        }

        private void RenderClasses()
        {
            try
            {
                this.m_workInfo.AddInfornation("выполняется отрисовка данных по классам");
                this.m_renderHandler.DrawClasses();
                this.btn_renderClasses.Enabled = false;
                this.btn_renderClusters.Enabled = true;
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
            }
        }

        private void RenderClusters()
        {
            try
            {
                this.m_workInfo.AddInfornation("выполняется отрисовка данных по кластерам");
                this.m_renderHandler.DrawClustersAndCenters();
                this.btn_renderClasses.Enabled = true;
                this.btn_renderClusters.Enabled = false;
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
