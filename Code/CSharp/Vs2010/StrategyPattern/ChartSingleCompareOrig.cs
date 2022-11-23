using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompareOrig : Form
    {
        private const int ct_BarData = 150;
        private const string jjD_splitDisplay = "splitdisplay";
        private const string jjd_large = "rpfll";
        private int ct;

        private Bitmap drawArea;
        private string jjReq1205;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }

        public void ShowChart(int ct, string jjReq1205, bool ifTrueShowDialog)
        {
            this.ct = ct;
            this.jjReq1205 = jjReq1205;
            drawArea = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
            if (ifTrueShowDialog)
            {
                ShowDialog();
            }
        }

        private void InitializeDrawArea()
        {
            Graphics.FromImage(drawArea).Clear(Color.LightYellow);
        }

        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs eventArgs)
        {
            eventArgs.Graphics.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void DrawChart()
        {
            var jjD = this.jjReq1205;
            var g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);

            RenderChartBackground(jjD, g);

            var (data, otherData) = Data(jjD, g);

            try
            {
                if (!(g.DpiX == 300) ||
                    (g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                     (data == null || !data.StartsWith("hold"))))
                    Invalidate();
            }
            catch (ArgumentException ex)
            {
                Invalidate();
            }
        }

        private (string data, string otherData) Data(string jjD, Graphics g)
        {
            var (data, otherData, someOtherDataObject) = FillAllData(jjD);

            
            if (ct == ct_BarData)
            {
                if (jjD == jjD_splitDisplay)
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

            if (ct == ct_BarData)
            {
                if (jjD == jjd_large)
                    data = "Bar Data\nLarge";
                else
                    data = "Bar Data\nSmall";
            }
            else
            {
                if (jjD == jjd_large)
                    otherData = "Pie Data\nLarge";
                else
                    someOtherDataObject = "Pie Data\nSmall";
            }

            return (data, otherData, someOtherDataObject);
        }

        private void RenderChartBackground(string jjD, Graphics g)
        {
            SolidBrush brush;
            if (ct == ct_BarData)
            {
                if (jjD == jjd_large)
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
                if (jjD != jjd_large)
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