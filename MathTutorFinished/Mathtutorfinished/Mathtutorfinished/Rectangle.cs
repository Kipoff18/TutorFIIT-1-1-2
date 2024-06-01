using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MathTutor
{
    public abstract class Figure
    {
        public int Number { get; protected set; }
        public abstract void PrintCords();
        public abstract double Perimeter();
        public abstract double Square();
        public abstract double RemotePoint();
        public abstract void Rotate(double angle);
        public abstract void Move(int offsetX, int offsetY);
        public abstract void Resize(double widthFactor, double heightFactor);
    }

    public class Rectangle : Figure
    {
        public Point A;
        public Point B;
        public Point C;
        public Point D;
        public Point O;
        private static int next_number = 1;

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
                O = new Point((A.X + B.X + C.X + D.X) / 4, (A.Y + B.Y + C.Y) / 4);
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

        public override void PrintCords()
        {
            Console.WriteLine($"A({A.X},{A.Y})\nB({B.X},{B.Y})\nC({C.X},{C.Y})\nD({D.X},{D.Y})");
        }

        public override double Perimeter() => (GetDistance(A, B) + GetDistance(B, C)) * 2;

        public override double Square() => GetDistance(A, B) * GetDistance(B, C);

        public override double RemotePoint()
        {
            var distances = new List<double>
            {
                GetDistance(new Point(0, 0), A),
                GetDistance(new Point(0, 0), B),
                GetDistance(new Point(0, 0), C),
                GetDistance(new Point(0, 0), D)
            };
            return distances.Max();
        }

        public override void Rotate(double angle)
        {
            double angleRadians = angle * Math.PI / 180.0;
            A = RotatePoint(A, O, angleRadians);
            B = RotatePoint(B, O, angleRadians);
            C = RotatePoint(C, O, angleRadians);
            D = RotatePoint(D, O, angleRadians);

            Point RotatePoint(Point point, Point center, double angle)
            {
                int translatedX = point.X - center.X;
                int translatedY = point.Y - center.Y;

                int rotatedX = (int)(translatedX * Math.Cos(angle) - translatedY * Math.Sin(angle));
                int rotatedY = (int)(translatedX * Math.Sin(angle) + translatedY * Math.Cos(angle));

                return new Point(rotatedX + center.X, rotatedY + center.Y);
            }
        }

        public override void Move(int offsetX, int offsetY)
        {
            A.X += offsetX;
            A.Y += offsetY;
            B.X += offsetX;
            B.Y += offsetY;
            C.X += offsetX;
            C.Y += offsetY;
            D.X += offsetX;
            D.Y += offsetY;
        }

        public override void Resize(double widthFactor, double heightFactor)
        {
            int newWidth = (int)(widthFactor * (C.X - A.X));
            int newHeight = (int)(heightFactor * (B.Y - A.Y));

            B.Y = A.Y + newHeight;
            C.X = A.X + newWidth;
            D.X = C.X;
            D.Y = B.Y;
        }
    }

    public class Ellipse : Figure
    {
        public Point Center;
        public double RadiusX;
        public double RadiusY;
        private static int next_number = 1;

        public Ellipse(Point center, double radiusX, double radiusY)
        {
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;
            Number = next_number++;
        }

        public override void PrintCords()
        {
            Console.WriteLine($"Центр({Center.X},{Center.Y}), РадиусX = {RadiusX}, РадиусY = {RadiusY}");
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Math.Sqrt((RadiusX * RadiusX + RadiusY * RadiusY) / 2);
        }

        public override double Square()
        {
            return Math.PI * RadiusX * RadiusY;
        }

        public override double RemotePoint()
        {
            var distances = new List<double>
            {
                GetDistance(new Point(0, 0), new Point(Center.X + (int)RadiusX, Center.Y)),
                GetDistance(new Point(0, 0), new Point(Center.X - (int)RadiusX, Center.Y)),
                GetDistance(new Point(0, 0), new Point(Center.X, Center.Y + (int)RadiusY)),
                GetDistance(new Point(0, 0), new Point(Center.X, Center.Y - (int)RadiusY))
            };
            return distances.Max();
        }

        private double GetDistance(Point A, Point B)
        {
            double deltaX = B.X - A.X;
            double deltaY = B.Y - A.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public override void Rotate(double angle)
        {
            // Ellipses are symmetric about their center, rotating an ellipse doesn't change its geometry
            Console.WriteLine("Поворот эллипса не изменяет его координаты, так как эллипс симметричен относительно центра.");
        }

        public override void Move(int offsetX, int offsetY)
        {
            Center.X += offsetX;
            Center.Y += offsetY;
        }

        public override void Resize(double widthFactor, double heightFactor)
        {
            RadiusX *= widthFactor;
            RadiusY *= heightFactor;
        }

        public bool IsCircle()
        {
            return RadiusX == RadiusY;
        }
    }
}