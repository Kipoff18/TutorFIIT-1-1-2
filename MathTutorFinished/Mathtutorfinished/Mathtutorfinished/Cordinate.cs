using System;
using System.Collections.Generic;
using System.Linq;

namespace MathTutor
{
    public class Coordinate
    {
        List<Figure> Figures;

        public Coordinate(List<Figure> figures)
        {
            Figures = figures;
        }

        public Coordinate()
        {
            Figures = new List<Figure>();
        }

        public void PrintFigures()
        {
            foreach (var figure in Figures)
            {
                figure.PrintCords();
            }
        }

        public void PrintPerimeter(int figNum)
        {
            Console.WriteLine($"Периметр {figNum} фигуры: {Figures[figNum - 1].Perimeter()}");
        }

        public void PrintSquare(int figNum)
        {
            Console.WriteLine($"Площадь {figNum} фигуры: {Figures[figNum - 1].Square()}");
        }

        public void PrintRemotePoint(int figNum)
        {
            Console.WriteLine($"Расстояние до самой удаленной точки от начала координат фигуры {figNum}: {Figures[figNum - 1].RemotePoint()}");
        }

        public void RotatingFigures(int figNum, double angle)
        {
            Figures[figNum - 1].Rotate(angle);
            Console.WriteLine($"Фигура {figNum} повернута. Новые координаты:");
            Figures[figNum - 1].PrintCords();
        }

        public void MoveFigures(int figNum, int offsetX, int offsetY)
        {
            Figures[figNum - 1].Move(offsetX, offsetY);
            Console.WriteLine($"Фигура {figNum} перемещена. Новые координаты:");
            Figures[figNum - 1].PrintCords();
        }

        public void ResizeFigures(int figNum, double widthFactor, double heightFactor)
        {
            Figures[figNum - 1].Resize(widthFactor, heightFactor);
            Console.WriteLine($"Размер фигуры {figNum} изменен. Новые координаты:");
            Figures[figNum - 1].PrintCords();
        }

        public List<Figure> PredFigures(Predicate<Figure> p)
        {
            Console.Write("Количество фигур, удовлетворяющих предикату:\n");
            var result = new List<Figure>();
            foreach (var figure in Figures)
            {
                if (p(figure))
                {
                    Console.Write($"{figure.Number}, ");
                    result.Add(figure);
                }
            }
            Console.WriteLine();
            return result;
        }

        public void AddRectangle(int ax, int ay, int bx, int by, int cx, int cy, int dx, int dy)
        {
            Figures.Add(new Rectangle(new Point(ax, ay), new Point(bx, by), new Point(cx, cy), new Point(dx, dy)));
        }

        public void AddEllipse(int centerX, int centerY, double radiusX, double radiusY)
        {
            Figures.Add(new Ellipse(new Point(centerX, centerY), radiusX, radiusY));
        }

        public void PrintRectangleWithMinPerimeter()
        {
            var rectangles = Figures.OfType<Rectangle>();
            if (rectangles.Any())
            {
                var minPerimeterRectangle = rectangles.OrderBy(r => r.Perimeter()).First();
                Console.WriteLine($"Прямоугольник с минимальным периметром: {minPerimeterRectangle.Number}, периметр: {minPerimeterRectangle.Perimeter()}");
            }
            else
            {
                Console.WriteLine("Нет прямоугольников.");
            }
        }

        public void PrintCircleCount()
        {
            var circleCount = Figures.OfType<Ellipse>().Count(e => e.IsCircle());
            Console.WriteLine($"Количество эллипсов, являющихся окружностями: {circleCount}");
        }
    }
}
