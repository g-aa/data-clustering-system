using DataMiningSystem.Data.Realization.Math;
using DataMiningSystem.Data.Realization.Serializable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Forms.DataSetGenerator
{
    internal class NewSetRenderHandler : SetRenderHandler
    {
        private Dictionary<string, List<Point>> m_points;

        internal NewSetRenderHandler(PictureBox box) : base(box) 
        {
            this.m_points = new Dictionary<string, List<Point>>();
        }

        internal override void ClearSheet()
        {
            this.m_points.Clear();
            base.ClearSheet();
        }

        internal void AddPoint(Point point, string colorName)
        {
            Brush brush = new SolidBrush(this.m_colors.First(c => c.Name.Equals(colorName)));
            this.m_graphics.FillEllipse(brush, CalcPointRectangle(point, this.m_pointRadius));

            if (!this.m_points.ContainsKey(colorName))
            {
                this.m_points.Add(colorName, new List<Point>());
            }
            this.m_points[colorName].Add(point);
        }

        internal SerializableSet GetSerializableSet(String setName)
        {
            if (this.m_points.Count != 0)
            {
                SerializableSet set = new SerializableSet()
                {
                    SetName = setName,
                    Titles = new List<string> { "x1", "x2", "class", "cluster" }
                };

                foreach (KeyValuePair<string, List<Point>> kvp in this.m_points)
                {
                    kvp.Value.ForEach((Point p) =>
                    {
                        set.Points.Add(new SerializablePoint()
                        {
                            Class = kvp.Key,
                            Cluster = string.Empty,
                            Coordinates = PointToNormalizedCoordinates(p, this.m_bitmap.Width, this.m_bitmap.Height)
                        });
                    });
                }
                return set;
            }
            throw new ArgumentException("в сохраняемом наборе данных отсутствуют точки");
        }
    }
}
