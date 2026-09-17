using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapesDrawing
{
    public class Quadrilateral : IShape
    {
        public Point2D Start { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Point2D P1 => Start;
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }
        public Point2D P4 { get; private set; }

        public Quadrilateral(Point2D start, int width, int height)
        {
            Start = start;
            Width = width;
            Height = height;
            RecalculatePoints();
        }

        private void RecalculatePoints()
        {
            P2 = new Point2D(Start.X + Width, Start.Y);
            P3 = new Point2D(Start.X + Width, Start.Y + Height);
            P4 = new Point2D(Start.X, Start.Y + Height);
        }

        public void Move(int dx, int dy)
        {
            Start.AddX(dx);
            Start.AddY(dy);
            RecalculatePoints();
        }

        public void Draw(Canvas canvas)
        {
            DrawLine(canvas, P1, P2);
            DrawLine(canvas, P2, P3);
            DrawLine(canvas, P3, P4);
            DrawLine(canvas, P4, P1);
        }

        private void DrawLine(Canvas canvas, Point2D a, Point2D b)
        {
            Line line = new Line
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 3,
                X1 = a.X,
                Y1 = a.Y,
                X2 = b.X,
                Y2 = b.Y
            };
            canvas.Children.Add(line);
        }
    }
}
