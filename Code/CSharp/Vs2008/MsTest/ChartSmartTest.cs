using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGV;

namespace MsTest
{

	[TestClass]
	public class ChartSmartTest
	{
		[TestMethod]
		public void TestMainWindow()
		{
			frmMain main = new frmMain();
			main.Show();
			ApprovalTests.WinForms.Approvals.Approve(main);
		}

		[TestMethod]
		public void TestBarChartWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(150, "rpfll", false);
			chart.Show();
			ApprovalTests.WinForms.Approvals.Approve(chart);
		}

		[TestMethod]
		public void TestBarChartCompareWindow()
		{
			frmMain main = new frmMain();
			//main.Show();
			ChartSingleCompareOrig chart = main.LaunchChart(150, "splitdisplay", false);
			chart.Show();
			ApprovalTests.WinForms.Approvals.Approve(chart);
		}

		[TestMethod]
		public void TestPieChartWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(712, "rpfll", false);
			chart.Show();
			ApprovalTests.WinForms.Approvals.Approve(chart);
		}

		[TestMethod]
		public void TestPieChartCompareWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(712, "splitdisplay", false);
			chart.Show();
			ApprovalTests.WinForms.Approvals.Approve(chart);
		}
	}
}
