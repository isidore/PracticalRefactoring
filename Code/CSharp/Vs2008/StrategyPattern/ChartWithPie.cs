using System.Drawing;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartWithPie : Form
    {
        private Bitmap drawArea;
        private string chartType;

        public ChartWithPie()
        {
            InitializeComponent();
        }

        public void ShowChart(string chartType)
        {
            this.chartType = chartType;
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

        private void ChartWithPie_Paint(object sender, PaintEventArgs e)
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
            if (chartType == "Bar")
            {
                brush = new SolidBrush(Color.Red);
                g.FillRectangle(brush, 50, 100, 300, 300);
            }
            else
            {
                brush = new SolidBrush(Color.Blue);
                g.FillEllipse(brush, 50, 100, 320, 320);
            }
            brush.Dispose();
        }

        private void RenderData(Graphics g)
        {
            if (chartType == "Bar")
            {
                g.DrawString(GetData(), new Font("Arial", 40), new SolidBrush(Color.White), new PointF(60, 120));
            }
            else
            {
                g.DrawString(GetData(), new Font("Arial", 40), new SolidBrush(Color.Pink), new PointF(100, 220));
            }
        }

        private string GetData()
        {
            if (chartType == "Bar")
            {
                return "Bar Data";
            }
            else
            {
                return "Pie Data";
            }
        }
    }
}