using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Realization.Information;
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
    public class DataSetRenderHandler : AbstractRenderHandler
    {
        private IMathSet m_mathSet;

        private ClusteringResult m_cResult;

        public DataSetRenderHandler(Canvas canvas) : base(canvas) { }

        public void AddMathSet(IMathSet set)
        {
            this.m_mathSet = set;
            this.m_cResult = null;
        }

        public void AddClusteringResult(ClusteringResult set) 
        {
            this.m_cResult = set;
        }

        public void DrawClasses() 
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

            // настройка цвета и формы точки: 
            Dictionary<string, Color> colors = new Dictionary<string, Color>();
            for (int i = 0; i < this.m_mathSet.Classes.Length; i++)
            {
                if (!colors.ContainsKey(this.m_mathSet.Classes[i]))
                {
                    colors.Add(this.m_mathSet.Classes[i], (Color)ColorConverter.ConvertFromString(this.Colors[i]));
                }
            }
            
            // отрисока данных:
            this.m_mathSet.ForEach((IMathPoint p) => 
            {
                Point canvas_p = this.GetCanvasPoint(p);
                this.AddEllipseToCanvas(canvas_p, colors[p.Class]);
            });
        }

        public void DrawClustersAndCenters()
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

            // отрисовка кластеров и центров кластеризации:
            int i = 0;
            this.m_cResult.Centers.ForEach((IMathPoint cp) => 
            {
                Point canvas_cp = this.GetCanvasPoint(cp);
                Color color = (Color)ColorConverter.ConvertFromString(this.Colors[i]);

                // отрисовка центра:
                this.AddEllipseToCanvas(canvas_cp, color);

                // отрисовка данных:
                this.m_cResult.MathSet.ForEach((IMathPoint dp) => 
                {
                    if (cp.Cluster.Equals(dp.Cluster))
                    {
                        Point canvas_dp = this.GetCanvasPoint(dp);

                        // отрисовка точки данных:
                        this.AddEllipseToCanvas(canvas_dp, color);

                        // отрисовка линии связи центра и точки данных:
                        this.AddLineToCanvas(canvas_cp, canvas_dp, color);
                    }
                });
                i++;
            });

        }

        private Point GetCanvasPoint(IMathPoint p)
        {
            return new Point() 
            {
                X = this.m_canvas.Width*p[0],
                Y = this.m_canvas.Height * (1.0 - p[1])
            };
        }

        private void AddEllipseToCanvas(Point point, Color color)
        {
            Ellipse ellipse = new Ellipse()
            {
                Stroke = new SolidColorBrush(color),
                Width = 2 * this.m_pRadius,
                Height = 2 * this.m_pRadius,

            };
            this.m_canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, point.X);
            Canvas.SetTop(ellipse, point.Y);
        }

        private void AddLineToCanvas(Point p1, Point p2, Color color)
        {
            Line lile = new Line()
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = 2,
                X1 = p1.X + this.m_pRadius,
                Y1 = p1.Y + this.m_pRadius,
                X2 = p2.X + this.m_pRadius,
                Y2 = p2.Y + this.m_pRadius
            };
            this.m_canvas.Children.Add(lile);
        }
    }
}
