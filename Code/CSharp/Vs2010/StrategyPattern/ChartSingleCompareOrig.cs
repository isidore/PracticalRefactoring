using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompareOrig : Form
    {
        private const int ChartTypeBarData = 150;
        private const string JjDSplitDisplay = "splitdisplay";
        private const string JjdLarge = "rpfll";
        private const int _dpi300 = 300;
        private int _chartType;

        private Bitmap _drawArea;
        private string _jjReq1205;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }

        public void ShowChart(int chartType, string jjReq1205, bool showDialog)
        {
            _chartType = chartType;
            _jjReq1205 = jjReq1205;
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

            RenderChartBackground(g, _jjReq1205);

            var (data, otherData) = RenderData(g, _jjReq1205);

            SomeKindOfInvalidation(g, otherData, data);
        }

        private void SomeKindOfInvalidation(Graphics g, string otherData, string data)
        {
            try
            {
                if (!(g.DpiX == _dpi300) ||
                    (g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                     (data == null || !data.StartsWith("hold"))))
                {
                    Invalidate();
                }
            }
            catch (ArgumentException)
            {
                Invalidate();
            }
        }

        private (string data, string otherData) RenderData(Graphics g, string jjD)
        {
            var (data, otherData, someOtherDataObject) = FillAllData(jjD);

            
            if (_chartType == ChartTypeBarData)
            {
                if (jjD == JjDSplitDisplay)
                    g.DrawString(data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
                else
                    g.DrawString(data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
            }
            else
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

            return (data, otherData);
        }

        private (string data, string otherData, string someOtherDataObject) FillAllData(string jjD)
        {
            string data = null;
            var otherData = "";
            string someOtherDataObject = null;

            if (_chartType == ChartTypeBarData)
            {
                if (jjD == JjdLarge)
                    data = "Bar Data\nLarge";
                else
                    data = "Bar Data\nSmall";
            }
            else
            {
                if (jjD == JjdLarge)
                    otherData = "Pie Data\nLarge";
                else
                    someOtherDataObject = "Pie Data\nSmall";
            }

            return (data, otherData, someOtherDataObject);
        }

        private void RenderChartBackground(Graphics g, string jjD)
        {
            SolidBrush brush;
            if (_chartType == ChartTypeBarData)
            {
                if (jjD == JjdLarge)
                {
                    brush = new SolidBrush(Color.Red);
                    g.FillRectangle(brush, 50, 100, 300, 300);
                }
                else
                {
                    brush = new SolidBrush(Color.Red);


                    g.FillRectangle(brush, 50, 100, 150, 150);
                }
            }
            else
            {
                if (jjD != JjdLarge)
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 50, 100, 160, 160);
                }
                else
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 50, 100, 320, 320);
                }
            }

            brush.Dispose();
        }
    }
}