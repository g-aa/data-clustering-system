using DataMiningSystem.Data.Realization.Serializable;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Forms.DataSetGenerator
{
    public partial class GeneratorForm : Form
    {
        private string m_selectedClass;

        private NewSetRenderHandler m_dsRenderHandler;

        public GeneratorForm()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // настройка обработчика отрисовки точек:
            this.m_dsRenderHandler = new NewSetRenderHandler(this.m_pbx_dataSet);
            this.m_pbx_dataSet.Image = this.m_dsRenderHandler.GetBitmap();

            this.m_cbx_classType.Items.AddRange(this.m_dsRenderHandler.ColorsName);
            this.m_cbx_classType.SelectedIndex = 1;
            this.m_selectedClass = this.m_cbx_classType.Items[this.m_cbx_classType.SelectedIndex] as string;
            this.m_cbx_classType.SelectedIndexChanged += this.m_cbx_classType_SelectedIndexChanged;

            this.m_btn_clear.Click += m_btn_clear_Click;
            this.m_btn_saveDataSet.Click += m_btn_saveDataSet_Click;

            this.m_pbx_dataSet.MouseDown += m_pbx_dataSet_MouseDown;
            this.m_pbx_dataSet.MouseMove += m_pbx_dataSet_MouseMove;
            this.m_pbx_dataSet.MouseLeave += m_pbx_dataSet_MouseLeave;

            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void m_pbx_dataSet_MouseLeave(object sender, EventArgs e)
        {
            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void m_pbx_dataSet_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pbx = sender as PictureBox;
            double[] coordinates = SetRenderHandler.PointToNormalizedCoordinates(e.Location, pbx.Width, pbx.Height);
            this.UpdateStatus(coordinates[0], coordinates[1]);
        }

        private void m_pbx_dataSet_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.m_dsRenderHandler.AddPoint(new Point(e.Location.X, e.Location.Y), this.m_selectedClass);
                this.m_pbx_dataSet.Image = this.m_dsRenderHandler.GetBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_btn_saveDataSet_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog fd = new SaveFileDialog() {
                    InitialDirectory = @"c:\",
                    Filter = "json files (*.json)|*.json|xml files (*.xml)|*.xml",
                    FilterIndex = 1,
                    RestoreDirectory = true })
                {
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(fd.FileName);
                        SerializableSet set = this.m_dsRenderHandler.GetSerializableSet(fd.FileName);
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
                        MessageBox.Show("набор с данными сохранен", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void m_btn_clear_Click(object sender, EventArgs e)
        {
            this.m_dsRenderHandler.ClearSheet();
            this.m_pbx_dataSet.Image = this.m_dsRenderHandler.GetBitmap();
        }

        private void m_cbx_classType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_selectedClass = this.m_cbx_classType.Items[this.m_cbx_classType.SelectedIndex] as string;
        }

        private void UpdateStatus(double x, double y)
        {
            this.m_lbl_status.Text = string.Format("cursor position: x = {0}, y = {1}", x.ToString("0.0000"), y.ToString("0.0000"));
        }
    }
}
