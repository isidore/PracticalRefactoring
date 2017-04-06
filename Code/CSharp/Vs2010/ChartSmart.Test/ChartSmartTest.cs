using ApprovalTests.Reporters;
using ApprovalTests.WinForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGV;

namespace MsTest
{

	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class ChartSmartTest
	{
		[TestMethod]
		public void TestMainWindow()
		{
			frmMain main = new frmMain();
			WinFormsApprovals.Verify(main);
		}

		[TestMethod]
		public void TestBarChartWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(150, "rpfll", false);
			WinFormsApprovals.Verify(chart);
		}

		[TestMethod]
		public void TestBarChartCompareWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(150, "splitdisplay", false);
			WinFormsApprovals.Verify(chart);
		}

		[TestMethod]
		public void TestPieChartWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(712, "rpfll", false);
			WinFormsApprovals.Verify(chart);
		}

		[TestMethod]
		public void TestPieChartCompareWindow()
		{
			frmMain main = new frmMain();
			ChartSingleCompareOrig chart = main.LaunchChart(712, "splitdisplay", false);
			WinFormsApprovals.Verify(chart);
		}
	}
}
