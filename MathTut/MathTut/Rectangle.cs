using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTut
{
    public class Rectangle
    {
        public Point A;
        public Point B;
        public Point C;
        public Point D;
        public Point O;
        private static int next_number = 1;
        public int Number;
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            double length1 = GetDistance(a, b);
            double length2 = GetDistance(b, c);
            double length3 = GetDistance(c, d);
            double length4 = GetDistance(d, a);
            if (length1 == length3 && length2 == length4 &&
                       GetDistance(a, c) == GetDistance(b, d))
            {
                A = a;
                B = b;
                C = c;
                D = d;
                O = new Point((A.X + B.X + C.X + D.X) / 4, (A.Y + B.Y + C.Y + D.Y) / 4);
                Number = next_number++;
            }
            else
            {
                throw new ArgumentException("Неправильные координаты");
            }
        }
        private double GetDistance(Point A, Point B)
        {
            double deltaX = B.X - A.X;
            double deltaY = B.Y - A.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        public void PrintCords()
        {
            Console.WriteLine($"A({A.X},{A.Y})\nB({B.X},{B.Y})\nC({C.X},{C.Y})\nD({D.X},{D.Y})");
        }
        public double Perimeter() => (GetDistance(A, B) + GetDistance(B, C)) * 2;
        public double Square() => GetDistance(A, B) * GetDistance(B, C);
        public double RemotePoint()
        {
            var distances = new List<double>();
            distances.Add(GetDistance(new Point(0, 0), A));
            distances.Add(GetDistance(new Point(0, 0), B));
            distances.Add(GetDistance(new Point(0, 0), C));
            distances.Add(GetDistance(new Point(0, 0), D));
            return distances.Max();
        }
        public void RotateRectangle(double angle)
        {
            double angleRadians = angle * Math.PI / 180.0;
            A = RotatePoint(A, O, angleRadians);
            B = RotatePoint(B, O, angleRadians);
            C = RotatePoint(C, O, angleRadians);
            D = RotatePoint(D, O, angleRadians);
            Point RotatePoint(Point point, Point center, double angle)
            {
                // Вычисляем смещение точки относительно центра
                int translatedX = point.X - center.X;
                int translatedY = point.Y - center.Y;

                // Вычисляем новые координаты точки после поворота
                int rotatedX = (int)(translatedX * Math.Cos(angle) - translatedY * Math.Sin(angle));
                int rotatedY = (int)(translatedX * Math.Sin(angle) + translatedY * Math.Cos(angle));

                // Возвращаем координаты повернутой точки, смещенные обратно к исходному центру
                return new Point(rotatedX + center.X, rotatedY + center.Y);
            }
        }
        public void MoveRectangle(int offsetX, int offsetY)
        {
            // Изменяем координаты каждой вершины фигуры
            A.X += offsetX;
            A.Y += offsetY;

            B.X += offsetX;
            B.Y += offsetY;

            C.X += offsetX;
            C.Y += offsetY;

            D.X += offsetX;
            D.Y += offsetY;
        }
        public void ResizeRectangle(double widthFactor, double heightFactor)
        {
            // Изменяем координаты каждой вершины фигуры
            int newWidth = (int)(widthFactor * (C.X - A.X));
            int newHeight = (int)(heightFactor * (B.Y - A.Y));

            B.Y = A.Y + newHeight;
            C.X = A.X + newWidth;
            D.X = C.X;
            D.Y = B.Y;
        }
    }
}
