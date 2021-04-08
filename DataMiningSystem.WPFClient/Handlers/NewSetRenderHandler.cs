﻿using DataMiningSystem.Data.Realization.Serializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DataMiningSystem.WPFClient.Handlers
{
    public class NewSetRenderHandler : AbstractRenderHandler
    {
        private Dictionary<string, List<Point>> m_points;

        public NewSetRenderHandler(Canvas canvas) : base(canvas)
        {
            this.m_points = new Dictionary<string, List<Point>>();
        }

        public int PointsCount
        {
            get
            {
                return this.m_points.Sum(kvp => { return kvp.Value.Count; });
            }
        }

        public new void ClearSheet()
        {
            base.ClearSheet();
            this.m_points.Clear();
        }

        public void DrawDataPoint(Point point, string colorName)
        {
            Ellipse ellipse = new Ellipse() 
            { 
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorName)), 
                Width = 2*this.m_pRadius, 
                Height = 2*this.m_pRadius 
            };
            this.m_canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, point.X - this.m_pRadius);
            Canvas.SetTop(ellipse, point.Y - this.m_pRadius);

            if (!this.m_points.ContainsKey(colorName))
            {
                this.m_points.Add(colorName, new List<Point>());
            }
            this.m_points[colorName].Add(point);
        }

        public SerializableSet GetSerializableSet(String setName)
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
                            Coordinates = PointToNormalizedCoordinates(p, this.m_canvas.Width, this.m_canvas.Height)
                        });
                    });
                }
                return set;
            }
            throw new ArgumentException("в сохраняемом наборе данных отсутствуют точки");
        }

        public static double[] PointToNormalizedCoordinates(Point point, double width, double height)
        {
            return new double[] { point.X / width, (height - point.Y) / height };
        }
    }
}
