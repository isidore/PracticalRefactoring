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
            LaunchChart(150, "rpfll", true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboChartType.SelectedIndex = 0;
            cboDisplayType.SelectedIndex = 0;
        }
        

        private void btnWithPie_Click(object sender, EventArgs e)
        {
        	LaunchChart(GetChartType(), "rpfll", true);
        }

        private void btnShowSingleCompare_Click(object sender, EventArgs e)
        {
            int chartType;
            string displayType;
            
            chartType = GetChartType();
            displayType = GetDisplayType();

            LaunchChart(chartType, displayType, true);
        }

    	private string GetDisplayType()
    	{
    		string displayType;
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
    		return displayType;
    	}

    	private int GetChartType()
    	{
    		int chartType;
    		switch (cboChartType.Text)
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
    		return chartType;
    	}

    	public ChartSingleCompareOrig LaunchChart(int chartType, string displayType, bool asDialog)
        {
            ChartSingleCompareOrig chartSingleCompareOrig = new ChartSingleCompareOrig();
            chartSingleCompareOrig.ShowChart(chartType, displayType, asDialog);
            return chartSingleCompareOrig;
        }
    }
}