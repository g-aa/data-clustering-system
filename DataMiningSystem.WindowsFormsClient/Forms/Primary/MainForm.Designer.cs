namespace DataMiningSystem.WindowsFormsClient.Forms.Primary
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.m_lbl_maxIter = new System.Windows.Forms.Label();
            this.m_cbx_initType = new System.Windows.Forms.ComboBox();
            this.m_tbx_maxIter = new System.Windows.Forms.TextBox();
            this.m_tbx_clastersCount = new System.Windows.Forms.TextBox();
            this.m_lbl_clasters = new System.Windows.Forms.Label();
            this.m_lbl_initType = new System.Windows.Forms.Label();
            this.m_btn_clustering = new System.Windows.Forms.Button();
            this.m_btn_loadDataSet = new System.Windows.Forms.Button();
            this.m_paintData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbx_distance = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbx_algoritmType = new System.Windows.Forms.ComboBox();
            this.m_btn_generator = new System.Windows.Forms.Button();
            this.m_tbx_log = new System.Windows.Forms.TextBox();
            this.m_btn_paintClasses = new System.Windows.Forms.Button();
            this.m_btn_paintClusters = new System.Windows.Forms.Button();
            this.m_pbx_clustersBinding = new System.Windows.Forms.PictureBox();
            this.m_cbx_algoritm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btn_datasetInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_paintData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_clustersBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lbl_maxIter
            // 
            this.m_lbl_maxIter.AutoSize = true;
            this.m_lbl_maxIter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lbl_maxIter.Location = new System.Drawing.Point(42, 17);
            this.m_lbl_maxIter.Name = "m_lbl_maxIter";
            this.m_lbl_maxIter.Size = new System.Drawing.Size(119, 14);
            this.m_lbl_maxIter.TabIndex = 0;
            this.m_lbl_maxIter.Text = "Max. iterations:";
            // 
            // m_cbx_initType
            // 
            this.m_cbx_initType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_cbx_initType.FormattingEnabled = true;
            this.m_cbx_initType.Location = new System.Drawing.Point(169, 156);
            this.m_cbx_initType.Name = "m_cbx_initType";
            this.m_cbx_initType.Size = new System.Drawing.Size(149, 22);
            this.m_cbx_initType.TabIndex = 1;
            // 
            // m_tbx_maxIter
            // 
            this.m_tbx_maxIter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_tbx_maxIter.Location = new System.Drawing.Point(169, 13);
            this.m_tbx_maxIter.Name = "m_tbx_maxIter";
            this.m_tbx_maxIter.Size = new System.Drawing.Size(149, 22);
            this.m_tbx_maxIter.TabIndex = 2;
            // 
            // m_tbx_clastersCount
            // 
            this.m_tbx_clastersCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_tbx_clastersCount.Location = new System.Drawing.Point(169, 41);
            this.m_tbx_clastersCount.Name = "m_tbx_clastersCount";
            this.m_tbx_clastersCount.Size = new System.Drawing.Size(149, 22);
            this.m_tbx_clastersCount.TabIndex = 3;
            // 
            // m_lbl_clasters
            // 
            this.m_lbl_clasters.AutoSize = true;
            this.m_lbl_clasters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lbl_clasters.Location = new System.Drawing.Point(49, 45);
            this.m_lbl_clasters.Name = "m_lbl_clasters";
            this.m_lbl_clasters.Size = new System.Drawing.Size(112, 14);
            this.m_lbl_clasters.TabIndex = 4;
            this.m_lbl_clasters.Text = "Clusters count:";
            // 
            // m_lbl_initType
            // 
            this.m_lbl_initType.AutoSize = true;
            this.m_lbl_initType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lbl_initType.Location = new System.Drawing.Point(14, 159);
            this.m_lbl_initType.Name = "m_lbl_initType";
            this.m_lbl_initType.Size = new System.Drawing.Size(147, 14);
            this.m_lbl_initType.TabIndex = 5;
            this.m_lbl_initType.Text = "Initializing method:";
            // 
            // m_btn_clustering
            // 
            this.m_btn_clustering.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_clustering.Location = new System.Drawing.Point(325, 75);
            this.m_btn_clustering.Name = "m_btn_clustering";
            this.m_btn_clustering.Size = new System.Drawing.Size(152, 25);
            this.m_btn_clustering.TabIndex = 6;
            this.m_btn_clustering.Text = "Clustering ";
            this.m_btn_clustering.UseVisualStyleBackColor = true;
            // 
            // m_btn_loadDataSet
            // 
            this.m_btn_loadDataSet.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_loadDataSet.Location = new System.Drawing.Point(325, 44);
            this.m_btn_loadDataSet.Name = "m_btn_loadDataSet";
            this.m_btn_loadDataSet.Size = new System.Drawing.Size(152, 25);
            this.m_btn_loadDataSet.TabIndex = 7;
            this.m_btn_loadDataSet.Text = "Load dataset";
            this.m_btn_loadDataSet.UseVisualStyleBackColor = true;
            // 
            // m_paintData
            // 
            chartArea1.Name = "ChartArea1";
            this.m_paintData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.m_paintData.Legends.Add(legend1);
            this.m_paintData.Location = new System.Drawing.Point(684, 13);
            this.m_paintData.Name = "m_paintData";
            this.m_paintData.Size = new System.Drawing.Size(1192, 872);
            this.m_paintData.TabIndex = 9;
            this.m_paintData.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(98, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Metrics:";
            // 
            // m_cbx_distance
            // 
            this.m_cbx_distance.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_cbx_distance.FormattingEnabled = true;
            this.m_cbx_distance.Location = new System.Drawing.Point(169, 127);
            this.m_cbx_distance.Name = "m_cbx_distance";
            this.m_cbx_distance.Size = new System.Drawing.Size(149, 22);
            this.m_cbx_distance.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Algorithm Type:";
            // 
            // m_cbx_algoritmType
            // 
            this.m_cbx_algoritmType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_cbx_algoritmType.FormattingEnabled = true;
            this.m_cbx_algoritmType.Location = new System.Drawing.Point(169, 98);
            this.m_cbx_algoritmType.Name = "m_cbx_algoritmType";
            this.m_cbx_algoritmType.Size = new System.Drawing.Size(149, 22);
            this.m_cbx_algoritmType.TabIndex = 13;
            // 
            // m_btn_generator
            // 
            this.m_btn_generator.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_generator.Location = new System.Drawing.Point(325, 13);
            this.m_btn_generator.Name = "m_btn_generator";
            this.m_btn_generator.Size = new System.Drawing.Size(152, 25);
            this.m_btn_generator.TabIndex = 15;
            this.m_btn_generator.Text = "Generate dataset";
            this.m_btn_generator.UseVisualStyleBackColor = true;
            // 
            // m_tbx_log
            // 
            this.m_tbx_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_tbx_log.Location = new System.Drawing.Point(14, 208);
            this.m_tbx_log.Multiline = true;
            this.m_tbx_log.Name = "m_tbx_log";
            this.m_tbx_log.ReadOnly = true;
            this.m_tbx_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_tbx_log.Size = new System.Drawing.Size(662, 211);
            this.m_tbx_log.TabIndex = 16;
            // 
            // m_btn_paintClasses
            // 
            this.m_btn_paintClasses.Enabled = false;
            this.m_btn_paintClasses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_paintClasses.Location = new System.Drawing.Point(525, 13);
            this.m_btn_paintClasses.Name = "m_btn_paintClasses";
            this.m_btn_paintClasses.Size = new System.Drawing.Size(152, 25);
            this.m_btn_paintClasses.TabIndex = 17;
            this.m_btn_paintClasses.Text = "Build classes";
            this.m_btn_paintClasses.UseVisualStyleBackColor = true;
            // 
            // m_btn_paintClusters
            // 
            this.m_btn_paintClusters.Enabled = false;
            this.m_btn_paintClusters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_paintClusters.Location = new System.Drawing.Point(525, 45);
            this.m_btn_paintClusters.Name = "m_btn_paintClusters";
            this.m_btn_paintClusters.Size = new System.Drawing.Size(152, 25);
            this.m_btn_paintClusters.TabIndex = 18;
            this.m_btn_paintClusters.Text = "Build clusters";
            this.m_btn_paintClusters.UseVisualStyleBackColor = true;
            // 
            // m_pbx_clustersBinding
            // 
            this.m_pbx_clustersBinding.Location = new System.Drawing.Point(14, 439);
            this.m_pbx_clustersBinding.Name = "m_pbx_clustersBinding";
            this.m_pbx_clustersBinding.Size = new System.Drawing.Size(663, 446);
            this.m_pbx_clustersBinding.TabIndex = 19;
            this.m_pbx_clustersBinding.TabStop = false;
            // 
            // m_cbx_algoritm
            // 
            this.m_cbx_algoritm.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_cbx_algoritm.FormattingEnabled = true;
            this.m_cbx_algoritm.Location = new System.Drawing.Point(169, 69);
            this.m_cbx_algoritm.Name = "m_cbx_algoritm";
            this.m_cbx_algoritm.Size = new System.Drawing.Size(149, 22);
            this.m_cbx_algoritm.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(84, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Algorithm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Processing info:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "Binding diagram:";
            // 
            // m_btn_datasetInfo
            // 
            this.m_btn_datasetInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_datasetInfo.Location = new System.Drawing.Point(525, 76);
            this.m_btn_datasetInfo.Name = "m_btn_datasetInfo";
            this.m_btn_datasetInfo.Size = new System.Drawing.Size(152, 25);
            this.m_btn_datasetInfo.TabIndex = 24;
            this.m_btn_datasetInfo.Text = "Dataset info";
            this.m_btn_datasetInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1890, 898);
            this.Controls.Add(this.m_btn_datasetInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cbx_algoritm);
            this.Controls.Add(this.m_pbx_clustersBinding);
            this.Controls.Add(this.m_btn_paintClusters);
            this.Controls.Add(this.m_btn_paintClasses);
            this.Controls.Add(this.m_tbx_log);
            this.Controls.Add(this.m_btn_generator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cbx_algoritmType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cbx_distance);
            this.Controls.Add(this.m_paintData);
            this.Controls.Add(this.m_btn_loadDataSet);
            this.Controls.Add(this.m_btn_clustering);
            this.Controls.Add(this.m_lbl_initType);
            this.Controls.Add(this.m_lbl_clasters);
            this.Controls.Add(this.m_tbx_clastersCount);
            this.Controls.Add(this.m_tbx_maxIter);
            this.Controls.Add(this.m_cbx_initType);
            this.Controls.Add(this.m_lbl_maxIter);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.Text = "Clustering Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.m_paintData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_clustersBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lbl_maxIter;
        private System.Windows.Forms.ComboBox m_cbx_initType;
        private System.Windows.Forms.TextBox m_tbx_maxIter;
        private System.Windows.Forms.TextBox m_tbx_clastersCount;
        private System.Windows.Forms.Label m_lbl_clasters;
        private System.Windows.Forms.Label m_lbl_initType;
        private System.Windows.Forms.Button m_btn_clustering;
        private System.Windows.Forms.Button m_btn_loadDataSet;
        private System.Windows.Forms.DataVisualization.Charting.Chart m_paintData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbx_distance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbx_algoritmType;
        private System.Windows.Forms.Button m_btn_generator;
        private System.Windows.Forms.TextBox m_tbx_log;
        private System.Windows.Forms.Button m_btn_paintClasses;
        private System.Windows.Forms.Button m_btn_paintClusters;
        private System.Windows.Forms.PictureBox m_pbx_clustersBinding;
        private System.Windows.Forms.ComboBox m_cbx_algoritm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btn_datasetInfo;
    }
}

