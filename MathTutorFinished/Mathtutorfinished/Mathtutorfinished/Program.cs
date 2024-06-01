using System;
using System.Collections.Generic;

namespace MathTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"======= РАДЫ ПРИВЕТСТВОВАТЬ ВАС В НАШЕМ ""РЕПЕТИТОРЕ ПО МАТЕМАТИКЕ""! =======");
            Console.WriteLine("Выберите раздел, которым хотите воспользоваться (букву a,b или c) (a-геометрия) (b-проверка знаний) (с-теория и контрольные): ");
            string playerAnswer;
            string result;
            bool ValidValues = false;
            do
            {
                playerAnswer = Console.ReadLine().ToLower().Trim();
                if (playerAnswer == "a" || playerAnswer == "b" || playerAnswer == "c")
                {
                    ValidValues = true;
                }

                result = playerAnswer;

                if (!ValidValues)
                {
                    Console.Write($"Это не может быть буквой раздела. Попробуйте ещё раз:");
                }
            }
            while (!ValidValues);


            switch (result)
            {
                case "a":
                    var answer = "";
                    Console.WriteLine("Вы выбрали симулятор геометрии");
                    var MainPlane = new Coordinate();
                    Console.WriteLine("Меню:\n1: Вывести координаты всех фигур\n2: Добавить прямоугольник\n3: Добавить эллипс\n4: Периметр фигуры\n5: Площадь фигуры\n6: Наиболее удаленная точка\n7: Поворот фигуры\n8: Перемещение фигуры по осям X и Y на заданные сдвиги\n9: Увеличение высоты и ширины фигуры на заданные коэффициенты\n10: Получение массива фигур согласно заданному предикату\n11: Прямоугольник с минимальным периметром\n12: Количество эллипсов, являющихся окружностями");
                    do
                    {
                        playerAnswer = Console.ReadLine().ToLower().Trim();
                        if (int.TryParse(playerAnswer, out int _))
                        {
                            ValidValues = true;
                        }

                        answer = playerAnswer;

                        if (!ValidValues)
                        {
                            Console.Write($"Это не может быть цифрой функции. Попробуйте ещё раз:");
                        }
                    }
                    while (!ValidValues);

                    switch (answer)
                    {
                        case "1":
                            MainPlane.PrintFigures();
                            break;
                        case "2":
                            Console.WriteLine("Введите координату 1 точки по x:");
                            var ax = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 1 точки по y:");
                            var ay = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 2 точки по x:");
                            var bx = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 2 точки по y:");
                            var by = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 3 точки по x:");
                            var cx = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 3 точки по y:");
                            var cy = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 4 точки по x:");
                            var dx = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату 4 точки по y:");
                            var dy = int.Parse(Console.ReadLine());
                            MainPlane.AddRectangle(ax, ay, bx, by, cx, cy, dx, dy);
                            break;
                        case "3":
                            Console.WriteLine("Введите координаты центра эллипса по x:");
                            var centerX = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координаты центра эллипса по y:");
                            var centerY = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите радиус по x:");
                            var radiusX = double.Parse(Console.ReadLine());
                            Console.WriteLine("Введите радиус по y:");
                            var radiusY = double.Parse(Console.ReadLine());
                            MainPlane.AddEllipse(centerX, centerY, radiusX, radiusY);
                            break;
                        case "4":
                            Console.WriteLine("Введите номер фигуры:");
                            var num1 = int.Parse(Console.ReadLine());
                            MainPlane.PrintPerimeter(num1);
                            break;
                        case "5":
                            Console.WriteLine("Введите номер фигуры:");
                            var num2 = int.Parse(Console.ReadLine());
                            MainPlane.PrintSquare(num2);
                            break;
                        case "6":
                            Console.WriteLine("Введите номер фигуры:");
                            var num3 = int.Parse(Console.ReadLine());
                            MainPlane.PrintRemotePoint(num3);
                            break;
                        case "7":
                            Console.WriteLine("Введите номер фигуры:");
                            var num4 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите количество градусов:");
                            var angle = double.Parse(Console.ReadLine());
                            MainPlane.RotatingFigures(num4, angle);
                            break;
                        case "8":
                            Console.WriteLine("Введите номер фигуры:");
                            var num5 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите перемещение по x:");
                            var offsetX = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите перемещение по y:");
                            var offsetY = int.Parse(Console.ReadLine());
                            MainPlane.MoveFigures(num5, offsetX, offsetY);
                            break;
                        case "9":
                            Console.WriteLine("Введите номер фигуры:");
                            var num6 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите коэффициент по x:");
                            var widthFactor = double.Parse(Console.ReadLine());
                            Console.WriteLine("Введите коэффициент по y:");
                            var heightFactor = double.Parse(Console.ReadLine());
                            MainPlane.ResizeFigures(num6, widthFactor, heightFactor);
                            break;
                        case "10":
                            // Example predicate to find rectangles
                            Console.WriteLine("Введите минимальную площадь:");
                            var minSquare = double.Parse(Console.ReadLine());
                            Predicate<Figure> predicate = figure => figure.Square() > minSquare;
                            var filteredFigures = MainPlane.PredFigures(predicate);
                            foreach (var fig in filteredFigures)
                            {
                                fig.PrintCords();
                            }
                            break;
                        case "11":
                            MainPlane.PrintRectangleWithMinPerimeter();
                            break;
                        case "12":
                            MainPlane.PrintCircleCount();
                            break;
                    }
                    break;

                case "b":
                    var gen = new Generator();
                    Console.Write("Выберите количество вариантов: ");
                    int numberOfVariants;
                    int result2;
                    bool ValidValues2 = false;
                    do
                    {
                        ValidValues2 = int.TryParse(Console.ReadLine(), out numberOfVariants);
                        result2 = numberOfVariants;

                        if (!ValidValues2)
                        {
                            Console.Write($"Это не может быть количеством вариантов. Попробуйте ещё раз:");
                        }
                    }
                    while (!ValidValues2);

                    Console.WriteLine("Теперь введите количество заданий: ");
                    int numberOfTasks;
                    int result3;
                    bool ValidValues3 = false;
                    do
                    {
                        ValidValues3 = int.TryParse(Console.ReadLine(), out numberOfTasks);
                        result3 = numberOfTasks;

                        if (!ValidValues3)
                        {
                            Console.Write($"Это не может быть количеством заданий. Попробуйте ещё раз:");
                        }
                    }
                    while (!ValidValues3);
                    Console.Clear();
                    gen.CreateVariationsFromFile(result2, result3);
                    break;

                case "c":
                    Console.Clear();
                    FormulaSimulator simulator = new FormulaSimulator();
                    simulator.Train();

                    // Добавьте вызовы методов для вывода статистики и информации о самых коротких формуле и самой длинной теореме
                    Training sim2=new Training();
                   // sim2.ShowStatistics();
                    sim2.ShowShortestFormulaAndLongestTheorem();
                    break;
            }
        }
    }
}
