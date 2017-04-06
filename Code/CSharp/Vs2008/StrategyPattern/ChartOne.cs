using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SGV
{
    public partial class ChartOne : Form
    {

        private Bitmap drawArea;

        public ChartOne()
        {
            InitializeComponent();
        }

        private void ChartOne_Load(object sender, EventArgs e)
        {
            drawArea = new Bitmap(this.ClientRectangle.Width, 
                                this.ClientRectangle.Height, 
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
        }

         private void InitializeDrawArea()    
         {      
             Graphics g;       
             g = Graphics.FromImage(drawArea);
             g.Clear(Color.LightYellow);    
         }

        private void ChartOne_Paint(object sender, PaintEventArgs e)
        {
            //Debug.Print("dang");
            Graphics g;
            g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }
        
        private void DrawChart()
        {
            Graphics g = Graphics.FromImage(drawArea);
            SolidBrush brush;
            
            InitializeDrawArea();

            brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, 50, 100, 300, 300);
            RenderData(g);
            g.Dispose();
            this.Invalidate();
        }

        private void RenderData(Graphics g)
        {
            g.DrawString(GetData(), new Font("Arial", 40), new SolidBrush(Color.White), new PointF(60, 120));
        }

        private string GetData()
        {
            return "Bar Data";
            
        }
    }
}