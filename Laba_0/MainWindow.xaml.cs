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

        private void BtnManualTriangle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Point2D p1 = new Point2D(int.Parse(TxtTX1.Text), int.Parse(TxtTY1.Text));
                Point2D p2 = new Point2D(int.Parse(TxtTX2.Text), int.Parse(TxtTY2.Text));
                Point2D p3 = new Point2D(int.Parse(TxtTX3.Text), int.Parse(TxtTY3.Text));
                shapes.Add(new Triangle(p1, p2, p3));
                RedrawAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые координаты точек треугольника.");
            }
        }

        private void BtnRandomRectangle_Click(object sender, RoutedEventArgs e)
        {
            int width = rnd.Next(20, 150);
            int height = rnd.Next(20, 150);

            int maxX = (int)Scene.Width - width;
            int maxY = (int)Scene.Height - height;

            Point2D start = new Point2D(rnd.Next(0, maxX + 1), rnd.Next(0, maxY + 1));
            shapes.Add(new Quadrilateral(start, width, height));
            RedrawAll();
        }

        private void BtnRandomSquare_Click(object sender, RoutedEventArgs e)
        {
            int side = rnd.Next(20, 150);

            int maxX = (int)Scene.Width - side;
            int maxY = (int)Scene.Height - side;

            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;

            Point2D start = new Point2D(rnd.Next(0, maxX + 1), rnd.Next(0, maxY + 1));
            shapes.Add(new Quadrilateral(start, side, side));
            RedrawAll();
        }

        private void BtnManualRectangle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Point2D start = new Point2D(int.Parse(TxtRX.Text), int.Parse(TxtRY.Text));
                int width = int.Parse(TxtRW.Text);
                int height = int.Parse(TxtRH.Text);
                shapes.Add(new Quadrilateral(start, width, height));
                RedrawAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения координат, ширины и высоты.");
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            shapes.Clear();
            Scene.Children.Clear();
        }
    }
}
