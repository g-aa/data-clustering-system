using DataMiningSystem.Data.Realization.Serializable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Handlers
{
    internal class NewDataSetRenderHandler : AbstractRenderHandler
    {
        private Dictionary<string, List<Point>> m_points;

        internal NewDataSetRenderHandler(PictureBox box) : base(box)
        {
            this.m_points = new Dictionary<string, List<Point>>();
        }

        internal new void ClearSheet()
        {
            this.m_points.Clear();
            base.ClearSheet();
        }

        internal void AddPoint(Point point, string sColor)
        {
            this.m_graphics.FillEllipse(
                new SolidBrush(
                    this.m_colors.First(c => c.Name.Equals(sColor))
                ), 
                GetRectangle(point, this.m_pRadius)
            );
            this.m_box.Refresh();

            if (!this.m_points.ContainsKey(sColor))
            {
                this.m_points.Add(sColor, new List<Point>());
            }
            this.m_points[sColor].Add(point);
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
                            Coordinates = this.GetCoordinatesFromPoint(p)
                        });
                    });
                }
                return set;
            }
            throw new ArgumentException("в сохраняемом наборе данных отсутствуют точки");
        }
    }
}
