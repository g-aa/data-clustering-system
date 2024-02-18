using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using DataClusteringSystem.Data.Abstraction.Math;

namespace DataClusteringSystem.WindowsFormsClient.Handlers
{
    internal abstract class AbstractRenderHandler
    {
        protected Int32 m_pRadius;

        protected Color m_backColor;

        protected Graphics m_graphics;

        protected PictureBox m_box;

        protected List<Color> m_colors;

        internal string[] Colors
        {
            get
            {
                return this.m_colors.Select(c => c.Name).ToArray();
            }
        }

        internal AbstractRenderHandler(PictureBox box) : this(box, Color.White, 5) { }

        private AbstractRenderHandler(PictureBox box, Color backColor, Int32 pRadius)
        {
            if (box != null)
            {
                this.m_pRadius = pRadius;
                this.m_backColor = backColor;
                this.m_box = box;

                this.m_box.Image = new Bitmap(box.Width, box.Height);

                this.m_graphics = Graphics.FromImage(this.m_box.Image);
                this.m_graphics.Clear(this.m_backColor);

                // настройка используемых цветов:
                string[] notUsedColors = { "White", "Black", "DarkYellow", "DarkGray", "Yellow", "Cyan", this.m_backColor.Name };
                this.m_colors = Enum.GetNames(typeof(ConsoleColor)).Where(s => !notUsedColors.Contains(s)).Select(s => Color.FromName(s)).ToList();
                return;
            }
            throw new ArgumentNullException("параметр конструктора PictureBox равен null");
        }

        protected void ClearSheet()
        {
            this.m_graphics.Clear(this.m_backColor);
        }

        internal Rectangle GetRectangle(Point point, int size)
        {
            return new Rectangle() 
            {
                X = point.X - size,
                Y = point.Y - size,
                Width = 2 * size,
                Height = 2 * size
            };
        }

        internal Point GetBitmapPoint(IMathPoint mathPoint)
        {
            return new Point()
            {
                X = (int)(mathPoint[0] * this.m_box.Width),
                Y = this.m_box.Height - (int)(mathPoint[1] * this.m_box.Height)
            };
        }

        internal double[] GetCoordinatesFromPoint(Point point)
        {
            return new double[] 
            { 
                (double)point.X / this.m_box.Width, 
                ((double)this.m_box.Height - point.Y) / this.m_box.Height 
            };
        }
    }
}