using DataMiningSystem.ClientLogic;
using DataMiningSystem.ClientLogic.Handlers;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;
using DataMiningSystem.WPFClient.Handlers;
using DataMiningSystem.WPFClient.Windows;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataMiningSystem.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkInfo<TextBox> m_workInfo;

        private ClusteringOptions m_options;
        
        private IMathSet m_mathSet;
        
        private ClusteringHandler m_clusteringHandler;

        private DataSetRenderHandler m_renderHandler;

        private BackgroundWorker bgw_toCluster;

        public MainWindow()
        {
            this.InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;

            // настройка лога:
            this.m_workInfo = new WorkInfo<TextBox>(this.tbx_log);
            this.m_workInfo.SettingOutputObject += (TextBox tbx, String s) => { tbx.Text = s; };
            // настройка обработчика отрисовки:
            this.m_renderHandler = new DataSetRenderHandler(this.cnv_dataSet);
            // настройка кластеризации:
            this.m_clusteringHandler = new ClusteringHandler();
            this.m_options = ClusteringOptions.Default;
            // количество кластеров:
            this.tbx_clustersCount.Text = this.m_options.ClusterCount.ToString();
            // максимальное число итераций:
            this.tbx_maxIteration.Text = this.m_options.MaxIterations.ToString();
            // способ инициализации:
            this.cbx_initMethod.ItemsSource = Enum.GetNames(typeof(InitializationType));
            this.cbx_initMethod.SelectedIndex = (int)this.m_options.Initialization;
            // метрика:
            this.cbx_metrics.ItemsSource = Enum.GetNames(typeof(DistanceMetricType));
            this.cbx_metrics.SelectedIndex = (int)this.m_options.Distance;
            // тип алгоритма (однопоточный, многопоточный):
            this.cbx_algorithmType.ItemsSource = Enum.GetNames(typeof(ModeType));
            this.cbx_algorithmType.SelectedIndex = (int)this.m_options.Mode;
            // алгоритм:
            this.cbx_algorithm.ItemsSource = Enum.GetNames(typeof(AlgorithmType));
            this.cbx_algorithm.SelectedIndex = (int)this.m_clusteringHandler.Algorithm;

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
            this.bgw_toCluster.DoWork += this.Bgw_toCluster_DoWork;
            this.bgw_toCluster.ProgressChanged += this.Bgw_toCluster_ProgressChanged;
            this.bgw_toCluster.RunWorkerCompleted += this.Bgw_toCluster_RunWorkerCompleted;
        }

        private void Bgw_toCluster_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void Bgw_toCluster_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private void Bgw_toCluster_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is BackgroundWorker worker)
            {
                worker.ReportProgress(0);
                this.m_clusteringHandler.Run(this.m_mathSet, this.m_options);
            }
        }

        private void Btn_renderClusters_Click(object sender, RoutedEventArgs e)
        {
            this.RenderClusters();
        }

        private void Btn_renderClasses_Click(object sender, RoutedEventArgs e)
        {
            this.RenderClasses();
        }

        private void Btn_load_Click(object sender, RoutedEventArgs e)
        {
            this.m_workInfo.AddInfornation("выбор подходящего набора данных");
            OpenFileDialog fd = new OpenFileDialog()
            {
                InitialDirectory = @"c:\",
                Filter = "json files (*.json)|*.json|xml files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if ((bool)fd.ShowDialog())
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

        private void Btn_datasetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (this.m_mathSet != null)
            {
                DataSetInfo info = this.m_mathSet.SetInformation;
                this.m_workInfo.AddInfornation(info.ToString());
            }
            else
            {
                this.m_workInfo.AddWarning("набор данных не загружен");
            }
        }

        private void Btn_clustering_Click(object sender, RoutedEventArgs e)
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

        private void Btn_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.m_workInfo.AddInfornation("запущен генератор наборов данных");
                GeneratorWindow window = new GeneratorWindow();
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
            }
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
            this.m_options.Distance = (DistanceMetricType)this.cbx_metrics.SelectedIndex;
            this.m_options.Initialization = (InitializationType)this.cbx_initMethod.SelectedIndex;
            this.m_clusteringHandler.Algorithm = (AlgorithmType)this.cbx_algorithm.SelectedIndex;
        }

        private void RenderClasses()
        {
            try
            {
                this.m_workInfo.AddInfornation("выполняется отрисовка данных по классам");
                this.m_renderHandler.DrawClasses();
                this.btn_renderClasses.IsEnabled = false;
                this.btn_renderClusters.IsEnabled = true;
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
                this.btn_renderClasses.IsEnabled = true;
                this.btn_renderClusters.IsEnabled = false;
            }
            catch (Exception ex)
            {
                this.m_workInfo.AddError(ex.Message);
            }
        }
    }
}
