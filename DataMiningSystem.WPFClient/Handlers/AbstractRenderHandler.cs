using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataMiningSystem.WPFClient.Handlers
{
    public class AbstractRenderHandler
    {
        protected readonly Int32 m_pRadius;
        
        public String[] Colors { get; private set; }
        
        protected readonly Canvas m_canvas;

        public AbstractRenderHandler(Canvas canvas) : this(canvas, 5)
        {

        }

        private AbstractRenderHandler(Canvas canvas, Int32 pRadius)
        {
            if (canvas != null)
            {
                this.m_canvas = canvas;
                this.m_pRadius = pRadius;

                // настройка используемых цветов:
                string[] notUsedColors = { "White", "Black", "DarkYellow", "DarkGray", "Yellow", "Cyan" };
                this.Colors = Enum.GetNames(typeof(ConsoleColor)).Where(s => !notUsedColors.Contains(s)).ToArray();
                return;
            }
            throw new ArgumentNullException("параметр конструктора Canvas равен null");
        }

        protected void ClearSheet()
        {
            this.m_canvas.Children.Clear();
        }
    }
}
