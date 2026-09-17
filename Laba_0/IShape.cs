using System.Windows.Controls;

namespace ShapesDrawing
{
    public interface IShape
    {
        void Draw(Canvas canvas);
        void Move(int dx, int dy);
    }
}
