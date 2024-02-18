using DataClusteringSystem.Data.Realization.Serializable;
using DataClusteringSystem.WindowsFormsClient.Handlers;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DataClusteringSystem.WindowsFormsClient.Forms
{
    public partial class GeneratorForm : Form
    {
        private string m_selectedClass;

        private NewDataSetRenderHandler m_renderHandler;

        public GeneratorForm()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.m_renderHandler = new NewDataSetRenderHandler(this.pbx_dataSet);

            this.cbx_classType.Items.AddRange(this.m_renderHandler.Colors);
            this.cbx_classType.SelectedIndex = 1;
            this.cbx_classType.SelectedIndexChanged += this.Cbx_classType_SelectedIndexChanged;
            this.m_selectedClass = this.cbx_classType.Items[this.cbx_classType.SelectedIndex] as string;

            this.btn_clear.Click += Btn_clear_Click;
            this.btn_saveDataSet.Click += Btn_saveDataSet_Click;

            this.pbx_dataSet.MouseDown += Pbx_dataSet_MouseDown;
            this.pbx_dataSet.MouseMove += Pbx_dataSet_MouseMove;
            this.pbx_dataSet.MouseLeave += Pbx_dataSet_MouseLeave;

            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void Pbx_dataSet_MouseLeave(object sender, EventArgs e)
        {
            this.UpdateStatus(double.NaN, double.NaN);
        }

        private void Pbx_dataSet_MouseMove(object sender, MouseEventArgs e)
        {
            double[] coordinates = this.m_renderHandler.GetCoordinatesFromPoint(e.Location);
            this.UpdateStatus(coordinates[0], coordinates[1]);
        }

        private void Pbx_dataSet_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.m_renderHandler.AddPoint(new Point(e.Location.X, e.Location.Y), this.m_selectedClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_saveDataSet_Click(object sender, EventArgs e)
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
                        MessageBox.Show("набор с данными сохранен", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            this.m_renderHandler.ClearSheet();
        }

        private void Cbx_classType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_selectedClass = this.cbx_classType.Items[this.cbx_classType.SelectedIndex] as string;
        }

        private void UpdateStatus(double x, double y)
        {
            this.m_lbl_status.Text = string.Format("cursor position: x = {0}, y = {1}", x.ToString("0.0000"), y.ToString("0.0000"));
        }
    }
}
