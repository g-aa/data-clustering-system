using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Realization.Information;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Forms.Primary
{
    internal class ClusteringResRenderHandler : SetRenderHandler
    {
        internal ClusteringResRenderHandler(PictureBox box) : base(box) { }

        internal void DrawDataset(ClusteringResult cr)
        {
            // очистить поле:
            this.ClearSheet();

            // построение центров кластеров:
            for (int i = 0; i < cr.Centers.Count; i++)
            {
                Brush brush = new SolidBrush(this.m_colors[i]);
                Pen pen = new Pen(brush);

                Point cp = CalcBitmapPoint(cr.Centers[i], this.m_bitmap);
                this.m_graphics.FillEllipse(brush, CalcPointRectangle(cp, m_pointRadius));

                // отрисовка связей центра и точки:
                cr.MathSet.ForEach((IMathPoint mp) => {
                    if (mp.Cluster.Equals(cr.Centers[i].Cluster))
                    {
                        Point p = CalcBitmapPoint(mp, this.m_bitmap);
                        this.m_graphics.FillEllipse(brush, CalcPointRectangle(p, this.m_pointRadius));
                        this.m_graphics.DrawLine(pen, cp, p);
                    }
                });
            }
        }
    }
}
