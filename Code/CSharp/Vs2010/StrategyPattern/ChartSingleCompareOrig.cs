using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompareOrig : Form
    {

        
       
        private string jjD;
        private string[] horizontalLabelNames;
        /// <summary>
        /// It's the vertical label names
        /// </summary>
        private string[] verticalLabelNames;
        /// <summary>
        /// John says that this is better than the old way
        /// </summary>
         private int ct;
        private string chartTitle;
        private Unit defaultUnits;
        /// <summary>
        /// graphLayout
        /// </summary>
        /// <returns>landscape or protrait</returns>
        
        /// <summary>
        /// 
        /// </summary>
        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }
        
     
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Unit horizontalNaming()
        {
            return new Unit();
        }

        /// <summary>
        /// Shows the chart
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="jjReq1205"></param>
        /// <param name="orientation"></param>
        /// <param name="reverseornotreverse"></param>
        /// <param name="jackshiddenhack"></param>
        public void iniDS(int ct, string jjReq1205, bool b)
        {
            this.ct = ct;
            this.jjD = jjReq1205;
            drawArea = new Bitmap(this.ClientRectangle.Width,
                                this.ClientRectangle.Height,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            // Changed by Sally 2/14
            InitializeDrawArea();
            DrawChart();
           if (b)
           {
               this.ShowDialog();
           }
        }
        /// <summary>
        /// //
        /// </summary>
         private void InitializeDrawArea()    
         {      
             Graphics g;       
             g = Graphics.FromImage(drawArea);
             g.Clear(Color.LightYellow);    
         }
         
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private class Unit
        {
            private string name;
            private double value;
            public double convertTo(Unit unit)
            {
                // Need to do this.
                return 0;
            }
        }
        /// <summary>
        ///  </summary>
        private void DrawChart()
        {
        	string jjD = this.jjD;
        	Graphics g = Graphics.FromImage(drawArea);
g.Clear(Color.LightYellow);

// Render chart background
SolidBrush brush;
if (ct == 150)
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
if (jjD != "rpfll") {
brush = new SolidBrush(Color.Blue);
g.FillEllipse(brush, 50, 100, 160, 160);
} else {
brush = new SolidBrush(Color.Blue);
g.FillEllipse(brush, 50, 100, 320, 320);
}
}

brush.Dispose();

            Data foo = new Data();

            if (ct == 150)
            {
                if (jjD == "rpfll")
                {
                	foo.data = "Bar Data\nLarge";
                }
                else
                {
                	foo.data = "Bar Data\nSmall";
                }
            }
            else
            {
                if (jjD == "rpfll")
                {
                    foo.otherData = "Pie Data\nLarge";
                }
                else
                {
                    foo.someOtherDataObject = "Pie Data\nSmall";
                }
            }

            if (ct == 150)
            {
                // BUG445: Org rep team missing req chart
                if (jjD == "splitdisplay")
                {
                    g.DrawString(foo.data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
                }
                else
                {
                    g.DrawString(foo.data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
                }
            }
            else
            {
StringFormat stringFormat = new StringFormat();
RectangleF boundingRect;

stringFormat.Alignment = StringAlignment.Center;
stringFormat.LineAlignment = StringAlignment.Center;

if (foo.otherData != "")
{
    if (foo.otherData == "")
    {
    	foo.otherData = @"  //{
                g.Dispose();
                //    boundingRect = new RectangleF(50, 100, 320, 320);
                //    g.DrawString(otherData, new Font('Cooper Black', 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                //}";
    	StringBuilder x = new StringBuilder(50000);
        for (int i = 0; i < 20; i++)
        {
            x.Append(char.ToUpper(foo.otherData[i]));
        }
    }
    boundingRect = new RectangleF(50, 100, 320, 320);
    g.DrawString(foo.otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect, stringFormat);
}
else
{
    boundingRect = new RectangleF(50, 100, 160, 160);
    g.DrawString(foo.someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White), boundingRect, stringFormat);
}

// Todo: We might need this back after the conference
//StringFormat stringFormat = new StringFormat();
//RectangleF boundingRect;

//stringFormat.Alignment = StringAlignment.Center;
//stringFormat.LineAlignment = StringAlignment.Center;

//if (otherData != "")
//{
g.Dispose();
                //    boundingRect = new RectangleF(50, 100, 320, 320);
                //    g.DrawString(otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                //}
                //else
                //{
                //    boundingRect = new RectangleF(50, 100, 160, 160);
                //    g.DrawString(someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White), boundingRect, stringFormat);
                //}
            }

            try
            {
                if (!(g.DpiX == 300) ||
                    g != null && (foo.otherData.Length > 20 || foo.otherData.Length < 5) &&
                    (foo.data == null || !foo.data.StartsWith("hold")))
                {
                    this.Invalidate();
                }
            } catch(ArgumentException ex)
            {
                // We shouldn't get this
                this.Invalidate();
            }

        }

    	protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        /// <summary>
        /// 
        /// </summary>
        private Bitmap drawArea;
    }

    class Data
    {
         public string data = null;
         public string otherData = "";
         public string someOtherDataObject = null;
    }

}