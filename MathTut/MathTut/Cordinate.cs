using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTut
{
    public class Coordinate
    {
        List<Rectangle> Figures;

        public Coordinate(List<Rectangle> figures)
        {
            Figures = figures;
        }
        public Coordinate()
        {
        }
        public void PrintFigures()
        {
            foreach (var figure in Figures)
            {
                Console.WriteLine($"{figure.Number} прямоугольник. Координаты:\nA({figure.A.X},{figure.A.Y})\nB({figure.B.X},{figure.B.Y})\nC({figure.C.X},{figure.C.Y})\nD({figure.D.X},{figure.D.Y})");
            }
        }
        public void PrintPerimeter(int recNum)
        {
            Console.WriteLine($"Периметр {recNum} прямоугольника представляет собой {Figures[recNum - 1].Perimeter()}");
        }
        public void PrintSquare(int recNum)
        {
            Console.WriteLine($"Площадь {recNum} прямоугольника представляет собойs {Figures[recNum - 1].Square()}");
        }
        public void PrintRemotePoint(int recNum)
        {
            Console.WriteLine($"Расстояние между началом координатной пластины и самой дальней точкой {recNum - 1} прямоугольника {Figures[recNum - 1].RemotePoint()}");
        }
        public void RotatingFigures(int recNum, double angle)
        {
            Figures[recNum - 1].RotateRectangle(angle);
            Console.WriteLine($"{Figures[recNum - 1].Number} прямоугольник повернут. Новые координаты:");
            Figures[recNum - 1].PrintCords();
        }
        public void MoveFigures(int recNum, int offsetX, int offsetY)
        {
            Figures[recNum - 1].MoveRectangle(offsetX, offsetY);
            Console.WriteLine($"{Figures[recNum - 1].Number} прямоугольник двигаем. Новые координаты:");
            Figures[recNum - 1].PrintCords();
        }
        public void ResizeFigures(int recNum, double widthFactor, double heightFactor)
        {

            Figures[recNum - 1].ResizeRectangle(widthFactor, heightFactor);
            Console.WriteLine($"{Figures[recNum - 1].Number} размер прямоугольника изменен. Новые координаты:");
            Figures[recNum - 1].PrintCords();
        }
        public List<Rectangle> PredFigures(Predicate<Rectangle> p)
        {
            Console.Write("Количество прямоугольников, удовлетворяющих предикату:\n");
            var result = new List<Rectangle>();
            foreach (var figure in Figures)
            {
                if (p(figure))
                    Console.Write($"{figure.Number}, ");
                result.Add(figure);
            }
            Console.WriteLine();
            return result;
        }
        public void AddRectangle(int ax, int ay, int bx, int by, int cx, int cy, int dx, int dy)
        {
            Figures.Add(new Rectangle(new Point(ax, ay), new Point(bx, by), new Point(cx, cy), new Point(dx, dy)));
        }
    }
}
