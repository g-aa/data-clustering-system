namespace DataClusteringSystem.WindowsFormsClient.Forms
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
            this.m_lbl_maxIter = new System.Windows.Forms.Label();
            this.cbx_initType = new System.Windows.Forms.ComboBox();
            this.tbx_maxIteration = new System.Windows.Forms.TextBox();
            this.tbx_clustersCount = new System.Windows.Forms.TextBox();
            this.m_lbl_clasters = new System.Windows.Forms.Label();
            this.m_lbl_initType = new System.Windows.Forms.Label();
            this.btn_clustering = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_distance = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_algorithmType = new System.Windows.Forms.ComboBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.tbx_log = new System.Windows.Forms.TextBox();
            this.btn_renderClasses = new System.Windows.Forms.Button();
            this.btn_renderClusters = new System.Windows.Forms.Button();
            this.pbx_clustersBinding = new System.Windows.Forms.PictureBox();
            this.cbx_algoritm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_datasetInfo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_clustersBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lbl_maxIter
            // 
            this.m_lbl_maxIter.AutoSize = true;
            this.m_lbl_maxIter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lbl_maxIter.Location = new System.Drawing.Point(42, 17);
            this.m_lbl_maxIter.Name = "m_lbl_maxIter";
            this.m_lbl_maxIter.Size = new System.Drawing.Size(119, 14);
            this.m_lbl_maxIter.TabIndex = 0;
            this.m_lbl_maxIter.Text = "Max. iterations:";
            // 
            // cbx_initType
            // 
            this.cbx_initType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_initType.FormattingEnabled = true;
            this.cbx_initType.Location = new System.Drawing.Point(169, 156);
            this.cbx_initType.Name = "cbx_initType";
            this.cbx_initType.Size = new System.Drawing.Size(149, 22);
            this.cbx_initType.TabIndex = 1;
            // 
            // tbx_maxIteration
            // 
            this.tbx_maxIteration.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_maxIteration.Location = new System.Drawing.Point(169, 13);
            this.tbx_maxIteration.Name = "tbx_maxIteration";
            this.tbx_maxIteration.Size = new System.Drawing.Size(149, 22);
            this.tbx_maxIteration.TabIndex = 2;
            // 
            // tbx_clustersCount
            // 
            this.tbx_clustersCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_clustersCount.Location = new System.Drawing.Point(169, 41);
            this.tbx_clustersCount.Name = "tbx_clustersCount";
            this.tbx_clustersCount.Size = new System.Drawing.Size(149, 22);
            this.tbx_clustersCount.TabIndex = 3;
            // 
            // m_lbl_clasters
            // 
            this.m_lbl_clasters.AutoSize = true;
            this.m_lbl_clasters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lbl_clasters.Location = new System.Drawing.Point(49, 45);
            this.m_lbl_clasters.Name = "m_lbl_clasters";
            this.m_lbl_clasters.Size = new System.Drawing.Size(112, 14);
            this.m_lbl_clasters.TabIndex = 4;
            this.m_lbl_clasters.Text = "Clusters count:";
            // 
            // m_lbl_initType
            // 
            this.m_lbl_initType.AutoSize = true;
            this.m_lbl_initType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lbl_initType.Location = new System.Drawing.Point(14, 159);
            this.m_lbl_initType.Name = "m_lbl_initType";
            this.m_lbl_initType.Size = new System.Drawing.Size(147, 14);
            this.m_lbl_initType.TabIndex = 5;
            this.m_lbl_initType.Text = "Initializing method:";
            // 
            // btn_clustering
            // 
            this.btn_clustering.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_clustering.Location = new System.Drawing.Point(325, 75);
            this.btn_clustering.Name = "btn_clustering";
            this.btn_clustering.Size = new System.Drawing.Size(152, 25);
            this.btn_clustering.TabIndex = 6;
            this.btn_clustering.Text = "Clustering ";
            this.btn_clustering.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_load.Location = new System.Drawing.Point(325, 44);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(152, 25);
            this.btn_load.TabIndex = 7;
            this.btn_load.Text = "Load dataset";
            this.btn_load.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(98, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Metrics:";
            // 
            // cbx_distance
            // 
            this.cbx_distance.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_distance.FormattingEnabled = true;
            this.cbx_distance.Location = new System.Drawing.Point(169, 127);
            this.cbx_distance.Name = "cbx_distance";
            this.cbx_distance.Size = new System.Drawing.Size(149, 22);
            this.cbx_distance.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(49, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Algorithm Type:";
            // 
            // cbx_algorithmType
            // 
            this.cbx_algorithmType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_algorithmType.FormattingEnabled = true;
            this.cbx_algorithmType.Location = new System.Drawing.Point(169, 98);
            this.cbx_algorithmType.Name = "cbx_algorithmType";
            this.cbx_algorithmType.Size = new System.Drawing.Size(149, 22);
            this.cbx_algorithmType.TabIndex = 13;
            // 
            // btn_create
            // 
            this.btn_create.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_create.Location = new System.Drawing.Point(325, 13);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(152, 25);
            this.btn_create.TabIndex = 15;
            this.btn_create.Text = "Generate dataset";
            this.btn_create.UseVisualStyleBackColor = true;
            // 
            // tbx_log
            // 
            this.tbx_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbx_log.Location = new System.Drawing.Point(14, 208);
            this.tbx_log.Multiline = true;
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.ReadOnly = true;
            this.tbx_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_log.Size = new System.Drawing.Size(680, 635);
            this.tbx_log.TabIndex = 16;
            // 
            // btn_renderClasses
            // 
            this.btn_renderClasses.Enabled = false;
            this.btn_renderClasses.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_renderClasses.Location = new System.Drawing.Point(542, 13);
            this.btn_renderClasses.Name = "btn_renderClasses";
            this.btn_renderClasses.Size = new System.Drawing.Size(152, 25);
            this.btn_renderClasses.TabIndex = 17;
            this.btn_renderClasses.Text = "Build classes";
            this.btn_renderClasses.UseVisualStyleBackColor = true;
            // 
            // btn_renderClusters
            // 
            this.btn_renderClusters.Enabled = false;
            this.btn_renderClusters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_renderClusters.Location = new System.Drawing.Point(542, 45);
            this.btn_renderClusters.Name = "btn_renderClusters";
            this.btn_renderClusters.Size = new System.Drawing.Size(152, 25);
            this.btn_renderClusters.TabIndex = 18;
            this.btn_renderClusters.Text = "Build clusters";
            this.btn_renderClusters.UseVisualStyleBackColor = true;
            // 
            // pbx_clustersBinding
            // 
            this.pbx_clustersBinding.Location = new System.Drawing.Point(734, 13);
            this.pbx_clustersBinding.Name = "pbx_clustersBinding";
            this.pbx_clustersBinding.Size = new System.Drawing.Size(836, 830);
            this.pbx_clustersBinding.TabIndex = 19;
            this.pbx_clustersBinding.TabStop = false;
            // 
            // cbx_algoritm
            // 
            this.cbx_algoritm.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_algoritm.FormattingEnabled = true;
            this.cbx_algoritm.Location = new System.Drawing.Point(169, 69);
            this.cbx_algoritm.Name = "cbx_algoritm";
            this.cbx_algoritm.Size = new System.Drawing.Size(149, 22);
            this.cbx_algoritm.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(84, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Algorithm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Processing info:";
            // 
            // btn_datasetInfo
            // 
            this.btn_datasetInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_datasetInfo.Location = new System.Drawing.Point(542, 75);
            this.btn_datasetInfo.Name = "btn_datasetInfo";
            this.btn_datasetInfo.Size = new System.Drawing.Size(152, 25);
            this.btn_datasetInfo.TabIndex = 24;
            this.btn_datasetInfo.Text = "Dataset info";
            this.btn_datasetInfo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(700, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "1.0";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(1542, 846);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "1.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(700, 829);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 27;
            this.label7.Text = "0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 861);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_datasetInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_algoritm);
            this.Controls.Add(this.pbx_clustersBinding);
            this.Controls.Add(this.btn_renderClusters);
            this.Controls.Add(this.btn_renderClasses);
            this.Controls.Add(this.tbx_log);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_algorithmType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_distance);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_clustering);
            this.Controls.Add(this.m_lbl_initType);
            this.Controls.Add(this.m_lbl_clasters);
            this.Controls.Add(this.tbx_clustersCount);
            this.Controls.Add(this.tbx_maxIteration);
            this.Controls.Add(this.cbx_initType);
            this.Controls.Add(this.m_lbl_maxIter);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.Text = "Clustering Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_clustersBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lbl_maxIter;
        private System.Windows.Forms.ComboBox cbx_initType;
        private System.Windows.Forms.TextBox tbx_maxIteration;
        private System.Windows.Forms.TextBox tbx_clustersCount;
        private System.Windows.Forms.Label m_lbl_clasters;
        private System.Windows.Forms.Label m_lbl_initType;
        private System.Windows.Forms.Button btn_clustering;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_distance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_algorithmType;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tbx_log;
        private System.Windows.Forms.Button btn_renderClasses;
        private System.Windows.Forms.Button btn_renderClusters;
        private System.Windows.Forms.PictureBox pbx_clustersBinding;
        private System.Windows.Forms.ComboBox cbx_algoritm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_datasetInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}