using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapesDrawing
{
    public class Triangle : IShape
    {
        public Point2D P1 { get; private set; }
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }

        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public void AddX(int x)
        {
            P1.AddX(x);
            P2.AddX(x);
            P3.AddX(x);
        }

        public void AddY(int y)
        {
            P1.AddY(y);
            P2.AddY(y);
            P3.AddY(y);
        }

        public void Move(int dx, int dy)
        {
            AddX(dx);
            AddY(dy);
        }

        public void Draw(Canvas canvas)
        {
            DrawLine(canvas, P1, P2);
            DrawLine(canvas, P2, P3);
            DrawLine(canvas, P3, P1);
        }

        private void DrawLine(Canvas canvas, Point2D a, Point2D b)
        {
            Line line = new Line
            {
                Stroke = Brushes.Red,
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
