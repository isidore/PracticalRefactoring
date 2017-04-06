namespace SGV
{
    partial class frmMain
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
            this.btnShowChart = new System.Windows.Forms.Button();
            this.cboChartType = new System.Windows.Forms.ComboBox();
            this.btnWithPie = new System.Windows.Forms.Button();
            this.btnShowSingleCompare = new System.Windows.Forms.Button();
            this.cboDisplayType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnShowChart
            // 
            this.btnShowChart.Location = new System.Drawing.Point(71, 29);
            this.btnShowChart.Name = "btnShowChart";
            this.btnShowChart.Size = new System.Drawing.Size(209, 42);
            this.btnShowChart.TabIndex = 0;
            this.btnShowChart.Text = "Show Chart";
            this.btnShowChart.UseVisualStyleBackColor = true;
            this.btnShowChart.Click += new System.EventHandler(this.btnShowChart_Click);
            // 
            // cboChartType
            // 
            this.cboChartType.FormattingEnabled = true;
            this.cboChartType.Items.AddRange(new object[] {
            "Bar",
            "Pie"});
            this.cboChartType.Location = new System.Drawing.Point(349, 100);
            this.cboChartType.Name = "cboChartType";
            this.cboChartType.Size = new System.Drawing.Size(146, 21);
            this.cboChartType.TabIndex = 1;
            // 
            // btnWithPie
            // 
            this.btnWithPie.Location = new System.Drawing.Point(72, 89);
            this.btnWithPie.Name = "btnWithPie";
            this.btnWithPie.Size = new System.Drawing.Size(207, 40);
            this.btnWithPie.TabIndex = 2;
            this.btnWithPie.Text = "Show Chart with Pie";
            this.btnWithPie.UseVisualStyleBackColor = true;
            this.btnWithPie.Click += new System.EventHandler(this.btnWithPie_Click);
            // 
            // btnShowSingleCompare
            // 
            this.btnShowSingleCompare.Location = new System.Drawing.Point(73, 150);
            this.btnShowSingleCompare.Name = "btnShowSingleCompare";
            this.btnShowSingleCompare.Size = new System.Drawing.Size(207, 40);
            this.btnShowSingleCompare.TabIndex = 3;
            this.btnShowSingleCompare.Text = "Show with Single or Compare";
            this.btnShowSingleCompare.UseVisualStyleBackColor = true;
            this.btnShowSingleCompare.Click += new System.EventHandler(this.btnShowSingleCompare_Click);
            // 
            // cboDisplayType
            // 
            this.cboDisplayType.FormattingEnabled = true;
            this.cboDisplayType.Items.AddRange(new object[] {
            "Single",
            "Compare"});
            this.cboDisplayType.Location = new System.Drawing.Point(349, 161);
            this.cboDisplayType.Name = "cboDisplayType";
            this.cboDisplayType.Size = new System.Drawing.Size(146, 21);
            this.cboDisplayType.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 553);
            this.Controls.Add(this.cboDisplayType);
            this.Controls.Add(this.btnShowSingleCompare);
            this.Controls.Add(this.btnWithPie);
            this.Controls.Add(this.cboChartType);
            this.Controls.Add(this.btnShowChart);
            this.Name = "frmMain";
            this.Text = "Big Chart Application";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowChart;
        private System.Windows.Forms.ComboBox cboChartType;
        private System.Windows.Forms.Button btnWithPie;
        private System.Windows.Forms.Button btnShowSingleCompare;
        private System.Windows.Forms.ComboBox cboDisplayType;
    }
}

