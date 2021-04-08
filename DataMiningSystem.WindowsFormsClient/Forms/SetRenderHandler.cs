using DataMiningSystem.Data.Abstraction.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningSystem.WindowsFormsClient.Forms
{
    abstract internal class SetRenderHandler
    {
        private Color m_backgroundColor;

        protected Int32 m_pointRadius;

        protected Bitmap m_bitmap;

        protected Graphics m_graphics;

        protected List<Color> m_colors;

        internal String[] ColorsName
        {
            get 
            {
                return this.m_colors.Select(c => c.Name).ToArray();
            }
        }

        internal SetRenderHandler(PictureBox box) : this(box, Color.White, 5) { }

        internal SetRenderHandler(PictureBox box, Color backgroundColor, Int32 pointRadius)
        {
            if (box != null)
            {
                this.m_bitmap = new Bitmap(box.Width, box.Height);
                this.m_graphics = Graphics.FromImage(this.m_bitmap);
                this.m_backgroundColor = backgroundColor;
                this.m_pointRadius = pointRadius;

                // настройка используемых цветов:
                string[] notUsedColors = { "White", "Black", "DarkYellow", "DarkGray", "Yellow", "Cyan", backgroundColor.Name };
                this.m_colors = Enum.GetNames(typeof(ConsoleColor)).Where(s => !notUsedColors.Contains(s)).Select(s => Color.FromName(s)).ToList();

                this.m_graphics.Clear(m_backgroundColor);
                return;
            }

            throw new ArgumentNullException("параметр конструктора PictureBox равен null");
        }

        virtual internal void ClearSheet()
        {
            this.m_graphics.Clear(m_backgroundColor);
        }

        internal Bitmap GetBitmap()
        {
            return this.m_bitmap;
        }

        internal static Point CalcBitmapPoint(IMathPoint mathPoint, Bitmap bitmap)
        {
            int x = (int)(mathPoint[0] * bitmap.Width);
            int y = bitmap.Height - (int)(mathPoint[1] * bitmap.Height);
            return new Point(x, y);
        }

        internal static Rectangle CalcPointRectangle(Point point, int size)
        {
            return new Rectangle(point.X - size, point.Y - size, 2 * size, 2 * size);
        }

        internal static double[] PointToNormalizedCoordinates(Point point, int width, int height)
        {
            return new double[] { (double)point.X / width, ((double)height - point.Y) / height };
        }
    }
}
