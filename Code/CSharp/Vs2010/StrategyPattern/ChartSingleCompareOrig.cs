using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public class ChartSize
    {
        public const string ChartSizeSplitDisplay = "splitdisplay";
        public const string ChartSizeLarge = "rpfll";
    }

    public partial class ChartSingleCompareOrig : Form
    {
        public const int ChartTypeBarData = 150;
        private int _chartType;

        private Bitmap _drawArea;
        private string _chartSize;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }

        public void ShowChart(int chartType, string chartSize, bool showDialog)
        {
            _chartType = chartType;
            _chartSize = chartSize;
            _drawArea = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
            if (showDialog)
            {
                ShowDialog();
            }
        }

        private void InitializeDrawArea()
        {
            Graphics.FromImage(_drawArea).Clear(Color.LightYellow);
        }

        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs eventArgs)
        {
            eventArgs.Graphics.DrawImage(_drawArea, 0, 0, _drawArea.Width, _drawArea.Height);
        }

        private void DrawChart()
        {
            var g = Graphics.FromImage(_drawArea);

            if (_chartType != ChartTypeBarData)
            {
                PieChart.DrawChart(this, g, this._chartType, this._chartSize);
            }
            else
            {
                BarChart.DrawChart(this, g, this._chartType, this._chartSize);
            }
        }
    }
}