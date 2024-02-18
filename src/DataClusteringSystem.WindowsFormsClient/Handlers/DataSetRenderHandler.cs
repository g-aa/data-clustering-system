using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DataClusteringSystem.Data.Abstraction.Math;
using DataClusteringSystem.Data.Realization.Information;

namespace DataClusteringSystem.WindowsFormsClient.Handlers
{
    internal class DataSetRenderHandler : AbstractRenderHandler
    {
        private IMathSet m_mathSet;

        private ClusteringResult m_cResult;

        internal DataSetRenderHandler(PictureBox box) : base(box) { }

        internal void AddMathSet(IMathSet set)
        {
            this.m_mathSet = set;
            this.m_cResult = null;
        }

        internal void AddClusteringResult(ClusteringResult set)
        {
            this.m_cResult = set;
        }

        internal void DrawClasses()
        {
            if (this.m_mathSet == null)
            {
                throw new ArgumentNullException("отображаемый набор данных равен null");
            }

            if (this.m_mathSet.CoordinatesCount != 2)
            {
                throw new Exception("отобразить можно только двумерные данные R2");
            }

            base.ClearSheet();

            // определение цветов классов:
            Dictionary<string, Color> colors = new Dictionary<string, Color>();
            for (int i = 0; i < this.m_mathSet.Classes.Length; i++)
            {
                if (!colors.ContainsKey(this.m_mathSet.Classes[i]))
                {
                    colors.Add(this.m_mathSet.Classes[i], this.m_colors[i]);
                }
            }

            // отрисовка точек по классам:
            this.m_mathSet.ForEach((IMathPoint p) => 
            {
                Brush brush = new SolidBrush(colors[p.Class]);
                Point bitmap_p = this.GetBitmapPoint(p);
                this.m_graphics.FillEllipse(brush, this.GetRectangle(bitmap_p, this.m_pRadius));
            });

            this.m_box.Refresh();
        }

        internal void DrawClustersAndCenters() 
        {
            if (this.m_cResult == null)
            {
                throw new ArgumentNullException("для отображаемого набора данных не выполнялась кластеризация");
            }

            if (this.m_cResult.MathSet.CoordinatesCount != 2)
            {
                throw new Exception("отобразить можно только двумерные данные R2");
            }

            base.ClearSheet();

            // построение центров кластеров:
            int i = 0;
            this.m_cResult.Centers.ForEach((IMathPoint cp) =>
            {
                Brush brush = new SolidBrush(this.m_colors[i]);
                Pen pen = new Pen(brush);

                Point bitmap_cp = this.GetBitmapPoint(cp);
                this.m_graphics.FillEllipse(brush, GetRectangle(bitmap_cp, this.m_pRadius));

                // отрисовка связей центра и точки:
                this.m_cResult.MathSet.ForEach((IMathPoint dp) => {
                    if (cp.Cluster.Equals(dp.Cluster))
                    {
                        Point bitmap_dp = this.GetBitmapPoint(dp);
                        this.m_graphics.FillEllipse(brush, this.GetRectangle(bitmap_dp, this.m_pRadius));
                        this.m_graphics.DrawLine(pen, bitmap_cp, bitmap_dp);
                    }
                });
                i++;
            });

            this.m_box.Refresh();
        }
    }
}