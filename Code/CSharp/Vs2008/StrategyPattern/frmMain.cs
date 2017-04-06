using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SGV
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            ChartOne chartOne = new ChartOne();
            chartOne.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboChartType.SelectedIndex = 0;
            cboDisplayType.SelectedIndex = 0;
        }
        

        private void btnWithPie_Click(object sender, EventArgs e)
        {
            ChartWithPie cwp = new ChartWithPie();
            cwp.ShowChart(cboChartType.Text);
        }

        private void btnShowSingleCompare_Click(object sender, EventArgs e)
        {
            int chartType;
            string displayType;
            
            switch(cboChartType.Text)
            {
                case "Bar":
                    chartType = 150;
                    break;
                case "Pie":
                    chartType = 712;
                    break;
                default:
                    chartType = 150;
                    break;
            }
            switch (cboDisplayType.Text)
            {
                case "Single":
                    displayType = "rpfll";
                    break;
                case "Compare":
                    displayType = "splitdisplay";
                    break;
                default:
                    displayType = "rpfll";
                    break;
            }

            LaunchChart(chartType, displayType, true);
        }

        public ChartSingleCompareOrig LaunchChart(int chartType, string displayType, bool asDialog)
        {
            ChartSingleCompareOrig chartSingleCompareOrig = new ChartSingleCompareOrig();
            chartSingleCompareOrig.iniDS(chartType, displayType, asDialog);
            return chartSingleCompareOrig;
        }
    }
}