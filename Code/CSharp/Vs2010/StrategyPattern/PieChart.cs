﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV
{
    public class PieChart
    {
        private const int Dpi300 = 300;

        public static void DrawChart(ChartSingleCompareOrig that, Graphics g, int thatChartType, string thatChartSize)
        {
            RenderChartBackground(thatChartType, g, thatChartSize);

            var (barData, pieData) = RenderData(thatChartType, FillAllData(thatChartType, thatChartSize), g, thatChartSize);

            Redraw(that, () => ShouldInvalidate(g, pieData, barData));
        }

        private static void Redraw(ChartSingleCompareOrig that, Func<bool> shouldInvalidate)
        {
            try
            {
                if (shouldInvalidate())
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
            return !(g.DpiX == Dpi300) ||
                   (g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                    (data == null || !data.StartsWith("hold")));
        }

        private static (string barData, string pieData) RenderData(int chartType, (string barData, string pieData, string pieDataSmall) fillAllData, Graphics g, string chartSize)
        {
            var (barData, pieData, someOtherDataObject) = fillAllData;

            DrawPie(g, pieData, someOtherDataObject);

            return (barData, pieData);
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

        private static (string barData, string pieData, string pieDataSmall) FillAllData(int chartType, string chartSize)
        {
            string barData = null;
            var pieData = "";
            string pieDataSmall = null;

            (pieData, pieDataSmall) = InitializePieData(chartSize, pieData, pieDataSmall);

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

        private static void RenderChartBackground(int chartType, Graphics g, string chartSize)
        {
            RenderBarChart2(g, chartSize);
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
    }
}