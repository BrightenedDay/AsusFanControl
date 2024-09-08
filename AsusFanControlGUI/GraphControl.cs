

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal class GraphControl : Control
    {
        public List<(int, int)> points;

        public GraphControl()
        {
            //this.BackColor = Color.FromArgb(45, 45, 45);
            this.points = new List<(int, int)> { (0, 1), (16, 2) }; ;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        public void SetPoints(List<(int, int)> points)
        {
            this.points = points;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics graphics)
        {
            Pen gridPen = new Pen(Color.LightGray, 1);
            Pen linePen = new Pen(Color.Blue, 2);
            Brush pointBrush = new SolidBrush(Color.Black);

            for (int x = 0; x < this.Width; x += 10)
            {
                graphics.DrawLine(gridPen, x, 0, x, this.Height);
            }

            for (int y = 0; y < this.Height; y += 10)
            {
                graphics.DrawLine(gridPen, 0, y, this.Width, y);
            }

            if (points == null || points.Count == 0)
                return;

            // Draw points and lines
            for (int i = 0; i < points.Count; i++)
            {
                var point = points[i];
                //graphics.FillEllipse(pointBrush, point.Item1, this.Height - point.Item2, 2, 2);
                graphics.FillEllipse(pointBrush, point.Item1 - 5, this.Height - point.Item2 - 10, 10, 10);

                if (i < points.Count - 1)
                {
                    var nextPoint = points[i + 1];
                    graphics.DrawLine(linePen, point.Item1 - 5, this.Height - point.Item2 - 10, nextPoint.Item1 - 5, this.Height - nextPoint.Item2 - 10);
                }
            }
        }
    }
}