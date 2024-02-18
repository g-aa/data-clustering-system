using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DataClusteringSystem.Data.Realization.Serializable;
using DataClusteringSystem.WPFClient.Handlers;

using Microsoft.Win32;

namespace DataClusteringSystem.WPFClient.Windows
{
    /// <summary>
    /// Interaction logic for GeneratorWindow.xaml
    /// </summary>
    public partial class GeneratorWindow : Window
    {
        private NewDataSetRenderHandler m_renderHandler;

        public GeneratorWindow()
        {
            this.InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;

            this.m_renderHandler = new NewDataSetRenderHandler(this.cnv_dataSet);

            this.cbx_classType.ItemsSource = this.m_renderHandler.Colors;
            this.cbx_classType.SelectedIndex = 1;

            this.btn_clear.Click += Btn_clear_Click;
            this.btn_save.Click += Btn_save_Click;

            this.cnv_dataSet.MouseDown += Cnv_dataSet_MouseDown;
            this.cnv_dataSet.MouseMove += Cnv_dataSet_MouseMove;
            this.cnv_dataSet.MouseLeave += Cnv_dataSet_MouseLeave;

            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void Cnv_dataSet_MouseLeave(object sender, EventArgs e)
        {
            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void Cnv_dataSet_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            double[] coordinates = this.m_renderHandler.GetCoordinatesFromPoint(e.GetPosition(canvas));
            this.UpdateStatus(coordinates[0], coordinates[1]);
        }

        private void Cnv_dataSet_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.m_renderHandler.DrawDataPoint(e.GetPosition(this.cnv_dataSet), (string)this.cbx_classType.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fd = new SaveFileDialog()
                {
                    InitialDirectory = @"c:\",
                    Filter = "json files (*.json)|*.json|xml files (*.xml)|*.xml",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if ((bool)fd.ShowDialog())
                {
                    FileInfo fi = new FileInfo(fd.FileName);
                    SerializableSet set = this.m_renderHandler.GetSerializableSet(fd.FileName);
                    if (fi.Extension.Equals(".xml"))
                    {
                        DataSetSerializer.SaveToXmlFile(fd.FileName, set);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(fd.FileName))
                        {
                            sw.WriteLine(DataSetSerializer.SetToJson(set));
                            sw.Flush();
                        }
                    }
                    MessageBox.Show("набор с данными сохранен", "Информация!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            this.m_renderHandler.ClearSheet();
        }

        private void UpdateStatus(double x, double y)
        {
            string format = "points count: {2}; cursor position: x = {0}, y = {1}";
            this.lbl_status.Content = string.Format(format, x.ToString("0.0000"), y.ToString("0.0000"), this.m_renderHandler.PointsCount);
        }
    }
}