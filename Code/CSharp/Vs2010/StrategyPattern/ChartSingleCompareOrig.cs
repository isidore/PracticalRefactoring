using System;
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
        private const int ChartTypeBarData = 150;
        private const int _dpi300 = 300;
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

            DrawChart(this, g);
        }

        private static void DrawChart(ChartSingleCompareOrig that, Graphics g)
        {
            that.RenderChartBackground(g, that._chartSize);

            var (barData, pieData) = that.RenderData(g, that._chartSize);

            Redraw(that, g, pieData, barData);
        }

        private static void Redraw(ChartSingleCompareOrig that, Graphics g, string otherData, string data)
        {
            try
            {
                if (ShouldInvalidate(g, otherData, data))
                {
                    that.Invalidate();
                }
            }
            catch (ArgumentException)
            {
                that.Invalidate();
            }
        }

        private static bool ShouldInvalidate(Graphics g, string otherData, string data)
        {
            return !(g.DpiX == _dpi300) ||
                   (g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                    (data == null || !data.StartsWith("hold")));
        }

        private (string barData, string pieData) RenderData(Graphics g, string chartSize)
        {
            var (barData, pieData, someOtherDataObject) = FillAllData(chartSize);

            
            if (_chartType == ChartTypeBarData)
            {
                DrawBar(g, chartSize, barData);
            }
            else
            {
                DrawPie(g, pieData, someOtherDataObject);
            }

            return (barData, pieData);
        }

        private static void DrawBar(Graphics g, string chartSize, string data)
        {
            if (chartSize == ChartSize.ChartSizeSplitDisplay)
                g.DrawString(data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
            else
                g.DrawString(data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
        }

        private static void DrawPie(Graphics g, string otherData, string someOtherDataObject)
        {
            var stringFormat = new StringFormat();
            RectangleF boundingRect;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (otherData != "")
            {
                boundingRect = new RectangleF(50, 100, 320, 320);
                g.DrawString(otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect,
                    stringFormat);
            }
            else
            {
                boundingRect = new RectangleF(50, 100, 160, 160);
                g.DrawString(someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White),
                    boundingRect, stringFormat);
            }

            g.Dispose();
        }

        private (string barData, string pieData, string pieDataSmall) FillAllData(string chartSize)
        {
            string barData = null;
            var pieData = "";
            string pieDataSmall = null;

            if (_chartType == ChartTypeBarData)
            {
                barData = InitializeBarData(chartSize);
            }
            else
            {
                (pieData, pieDataSmall) = InitializePieData(chartSize, pieData, pieDataSmall);
            }

            return (barData, pieData, pieDataSmall);
        }

        private static (string pieData, string pieDataSmall) InitializePieData(string chartSize, string pieData,
            string pieDataSmall)
        {
            if (chartSize == ChartSize.ChartSizeLarge)
            {
                pieData = "Pie Data\nLarge";
            }
            else
            {
                pieDataSmall = "Pie Data\nSmall";
            }

            return (pieData, pieDataSmall);
        }

        private static string InitializeBarData(string chartSize)
        {
            string barData;
            if (chartSize == ChartSize.ChartSizeLarge)
            {
                barData = "Bar Data\nLarge";
            }
            else
            {
                barData = "Bar Data\nSmall";
            }

            return barData;
        }

        private void RenderChartBackground(Graphics g, string chartSize)
        {
            if (_chartType == ChartTypeBarData)
            {
                RenderBarChart(g, chartSize);
            }
            else
            {
                RenderBarChart2(g, chartSize);
            }
        }

        private static void RenderBarChart2(Graphics g, string chartSize)
        {
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                if (chartSize != ChartSize.ChartSizeLarge)
                {
                    g.FillEllipse(brush, 50, 100, 160, 160);
                }
                else
                {
                    g.FillEllipse(brush, 50, 100, 320, 320);
                }
            }
        }

        private static void RenderBarChart(Graphics g, string chartSize)
        {
            using (var brush = new SolidBrush(Color.Red))
            {
                if (chartSize == ChartSize.ChartSizeLarge)
                {
                    g.FillRectangle(brush, 50, 100, 300, 300);
                }
                else
                {
                    g.FillRectangle(brush, 50, 100, 150, 150);
                }
            }
        }
    }
}