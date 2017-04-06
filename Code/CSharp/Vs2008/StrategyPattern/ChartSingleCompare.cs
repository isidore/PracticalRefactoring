using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompare : Form
    {
        private Bitmap drawArea;
        private int ct;
        private string jjD;

        public ChartSingleCompare()
        {
            InitializeComponent();
        }

        public void ShowChart(int ct, string jjReq1205)
        {
            this.ct = ct;
            this.jjD = jjReq1205;
            drawArea = new Bitmap(this.ClientRectangle.Width,
                                this.ClientRectangle.Height,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
            this.ShowDialog();
        }

         private void InitializeDrawArea()    
         {      
             Graphics g;       
             g = Graphics.FromImage(drawArea);
             g.Clear(Color.LightYellow);    
         }

        private void ChartSingleCompare_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }
        
        private void DrawChart()
        {
            Graphics g = Graphics.FromImage(drawArea);
            InitializeDrawArea();
            RenderChartBackground(g);
            RenderData(g);
            g.Dispose();
            this.Invalidate();
        }

        private void RenderChartBackground(Graphics g)
        {
            SolidBrush brush;
            if (ct == 406)
            {
                if (jjD == "rpfll")
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
                if (jjD != "rpfll")
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

        private void RenderData(Graphics g)
        {
            if (ct == 406)
            {
                // BUG445: Org rep team missing req chart
                if (jjD == "splitdisplay")
                {
                    g.DrawString(GetData(), new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
                }
                else
                {
                    g.DrawString(GetData(), new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120)); 
                }
            }
            else
            {
                StringFormat stringFormat = new StringFormat();
                RectangleF boundingRect;

                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                if (jjD == "rpfll")
                {
                    boundingRect = new RectangleF(50, 100, 320, 320);
                    g.DrawString(GetData(), new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                }
                else
                {
                    boundingRect = new RectangleF(50, 100, 160, 160);
                    g.DrawString(GetData(), new Font("Cooper Black", 20), new SolidBrush(Color.White), boundingRect, stringFormat);
                }
                
            }
        }

        private string GetData()
        {
            if (ct == 406)
            {
                if (jjD == "rpfll")
                {
                    return "Bar Data\nLarge";
                }
                else
                {
                    return "Bar Data\nSmall";
                }
            }
            else
            {
                if (jjD == "rpfll")
                {
                    return "Pie Data\nLarge";
                }
                else
                {
                    return "Pie Data\nSmall";
                }
            }
        }
        
    }
}