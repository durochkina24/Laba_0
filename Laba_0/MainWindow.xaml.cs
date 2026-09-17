using System;
using System.Collections.Generic;
using System.Windows;

namespace ShapesDrawing
{
    public partial class MainWindow : Window
    {
        private readonly List<IShape> shapes = new List<IShape>();
        private readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private int RandomX() => rnd.Next(0, (int)Scene.Width);
        private int RandomY() => rnd.Next(0, (int)Scene.Height);

        private void RedrawAll()
        {
            Scene.Children.Clear();
            foreach (var shape in shapes)
            {
                shape.Draw(Scene);
            }
        }

        private void BtnRandomTriangle_Click(object sender, RoutedEventArgs e)
        {
            Point2D p1 = new Point2D(RandomX(), RandomY());
            Point2D p2 = new Point2D(RandomX(), RandomY());
            Point2D p3 = new Point2D(RandomX(), RandomY());
            shapes.Add(new Triangle(p1, p2, p3));
            RedrawAll();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            shapes.Clear();
            Scene.Children.Clear();
        }
    }
}
