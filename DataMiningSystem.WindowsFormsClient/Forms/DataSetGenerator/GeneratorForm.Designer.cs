namespace DataMiningSystem.WindowsFormsClient.Forms.DataSetGenerator
{
    partial class GeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_btn_saveDataSet = new System.Windows.Forms.Button();
            this.m_cbx_classType = new System.Windows.Forms.ComboBox();
            this.m_btn_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lbl_status = new System.Windows.Forms.Label();
            this.m_pbx_dataSet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btn_saveDataSet
            // 
            this.m_btn_saveDataSet.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_saveDataSet.Location = new System.Drawing.Point(14, 13);
            this.m_btn_saveDataSet.Name = "m_btn_saveDataSet";
            this.m_btn_saveDataSet.Size = new System.Drawing.Size(141, 25);
            this.m_btn_saveDataSet.TabIndex = 0;
            this.m_btn_saveDataSet.Text = "Save dataset";
            this.m_btn_saveDataSet.UseVisualStyleBackColor = true;
            // 
            // m_cbx_classType
            // 
            this.m_cbx_classType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_cbx_classType.FormattingEnabled = true;
            this.m_cbx_classType.Location = new System.Drawing.Point(526, 13);
            this.m_cbx_classType.Name = "m_cbx_classType";
            this.m_cbx_classType.Size = new System.Drawing.Size(140, 22);
            this.m_cbx_classType.TabIndex = 1;
            // 
            // m_btn_clear
            // 
            this.m_btn_clear.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_btn_clear.Location = new System.Drawing.Point(162, 13);
            this.m_btn_clear.Name = "m_btn_clear";
            this.m_btn_clear.Size = new System.Drawing.Size(141, 25);
            this.m_btn_clear.TabIndex = 2;
            this.m_btn_clear.Text = "Clear";
            this.m_btn_clear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(436, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Class type:";
            // 
            // m_lbl_status
            // 
            this.m_lbl_status.AutoSize = true;
            this.m_lbl_status.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_lbl_status.Location = new System.Drawing.Point(14, 634);
            this.m_lbl_status.Name = "m_lbl_status";
            this.m_lbl_status.Size = new System.Drawing.Size(49, 14);
            this.m_lbl_status.TabIndex = 5;
            this.m_lbl_status.Text = "status";
            // 
            // m_pbx_dataSet
            // 
            this.m_pbx_dataSet.Location = new System.Drawing.Point(14, 44);
            this.m_pbx_dataSet.Name = "m_pbx_dataSet";
            this.m_pbx_dataSet.Size = new System.Drawing.Size(653, 587);
            this.m_pbx_dataSet.TabIndex = 6;
            this.m_pbx_dataSet.TabStop = false;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 658);
            this.Controls.Add(this.m_pbx_dataSet);
            this.Controls.Add(this.m_lbl_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btn_clear);
            this.Controls.Add(this.m_cbx_classType);
            this.Controls.Add(this.m_btn_saveDataSet);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GeneratorForm";
            this.Text = "Generator Form";
            ((System.ComponentModel.ISupportInitialize)(this.m_pbx_dataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btn_saveDataSet;
        private System.Windows.Forms.ComboBox m_cbx_classType;
        private System.Windows.Forms.Button m_btn_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lbl_status;
        private System.Windows.Forms.PictureBox m_pbx_dataSet;
    }
}