using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV
{
    public class BarChart
    {
        private const int _dpi300 = 300;

        public static void DrawChart(ChartSingleCompareOrig that, Graphics g, int thatChartType, string thatChartSize)
        {
            RenderChartBackground(thatChartType, g, thatChartSize);

            var (barData, pieData) = RenderData(thatChartType, FillAllData(thatChartType, thatChartSize), g, thatChartSize);

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

        private static (string barData, string pieData) RenderData(int chartType, (string barData, string pieData, string pieDataSmall) fillAllData, Graphics g, string chartSize)
        {
            var (barData, pieData, someOtherDataObject) = fillAllData;
            
            DrawBar(g, chartSize, barData);
            
            return (barData, pieData);
        }

        private static void DrawBar(Graphics g, string chartSize, string data)
        {
            if (chartSize == ChartSize.ChartSizeSplitDisplay)
                g.DrawString(data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
            else
                g.DrawString(data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
        }

        private static (string barData, string pieData, string pieDataSmall) FillAllData(int chartType, string chartSize)
        {
            string barData = null;
            var pieData = "";
            string pieDataSmall = null;

            barData = InitializeBarData(chartSize);

            return (barData, pieData, pieDataSmall);
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

        private static void RenderChartBackground(int chartType, Graphics g, string chartSize)
        {
            RenderBarChart(g, chartSize);
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
