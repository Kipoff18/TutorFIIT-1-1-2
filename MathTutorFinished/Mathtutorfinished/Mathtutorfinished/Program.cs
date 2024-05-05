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
                    Console.WriteLine("Меню:\n1:Вывести координаты всех фигур\n2:Добавить прямоугольник\n3:Периметр фигуры\n4:Площадь фигуры\n5:Наиболее удаленная точка\n6:Поворот прямоугольника\n7:Перемещение прямоугольника по осям X и Y на заданные сдвиги\n8:Увеличение высоты и ширины прямоугольника на заданные коэффициенты\n9:Получение массива прямоугольников согласно заданному предикату");
                    do
                    {
                        playerAnswer = Console.ReadLine().ToLower().Trim();
                        if (playerAnswer == "1" || playerAnswer == "2" || playerAnswer == "3" || playerAnswer == "4" || playerAnswer == "5" || playerAnswer == "6" || playerAnswer == "7" || playerAnswer == "8" || playerAnswer == "9")
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
                            Console.WriteLine("Введите координату 1 точки по x");
                            var ax = Console.ReadLine();
                            Console.WriteLine("Введите координату 1 точки по y");
                            var ay = Console.ReadLine();
                            Console.WriteLine("Введите координату 2 точки по x");
                            var bx = Console.ReadLine();
                            Console.WriteLine("Введите координату 2 точки по y");
                            var by = Console.ReadLine();
                            Console.WriteLine("Введите координату 3 точки по x");
                            var cx = Console.ReadLine();
                            Console.WriteLine("Введите координату 3 точки по y");
                            var cy = Console.ReadLine();
                            Console.WriteLine("Введите координату 4 точки по x");
                            var dx = Console.ReadLine();
                            Console.WriteLine("Введите координату 4 точки по y");
                            var dy = Console.ReadLine();
                            MainPlane.AddRectangle(Convert.ToInt32(ax), Convert.ToInt32(ay), Convert.ToInt32(bx), Convert.ToInt32(by), Convert.ToInt32(cx), Convert.ToInt32(cy), Convert.ToInt32(dx), Convert.ToInt32(dy));
                            break;
                        case "3":
                            Console.WriteLine("Введите номер прямоугольника");
                            var num = Console.ReadLine();
                            MainPlane.PrintPerimeter(Convert.ToInt32(num));
                            break;
                        case "4":
                            Console.WriteLine("Введите номер прямоугольника");
                            var num1 = Console.ReadLine();
                            MainPlane.PrintSquare(Convert.ToInt32(num1));
                            break;
                        case "5":
                            Console.WriteLine("Введите номер прямоугольника");
                            var num2 = Console.ReadLine();
                            MainPlane.PrintRemotePoint(Convert.ToInt32(num2));
                            break;
                        case "6":
                            Console.WriteLine("Введите номер прямоугольника");
                            var num3 = Console.ReadLine();
                            Console.WriteLine("Введите количество градусов");
                            var num4 = Console.ReadLine();
                            MainPlane.RotatingFigures(Convert.ToInt32(num3), Convert.ToInt32(num4));
                            break;
                        case "7":
                            Console.WriteLine("Введите номер прмяоугольника");
                            var num5 = Console.ReadLine();
                            Console.WriteLine("Введите перемещение по х");
                            var num6 = Console.ReadLine();
                            Console.WriteLine("Введите перемещение по у");
                            var num7 = Console.ReadLine();
                            MainPlane.MoveFigures(Convert.ToInt32(num5), Convert.ToInt32(num6), Convert.ToInt32(num7));
                            break;
                        case "8":
                            Console.WriteLine("Введите номер прямоугольника");
                            var num8 = Console.ReadLine();
                            Console.WriteLine("Введите коэффицент по х");
                            var num9 = Console.ReadLine();
                            Console.WriteLine("Введите коэффицент по y");
                            var num10 = Console.ReadLine();
                            MainPlane.ResizeFigures(Convert.ToInt32(num8), Convert.ToInt32(num9), Convert.ToInt32(num10));
                            break;
                        case "9":
                            //TODO
                            //var a = MainPlane.PredFigures()
                            Console.WriteLine(":(");
                            break;
                    }
                    break;

                case "b":
                    var gen = new Generator();
                    Console.Write("Выберите количесво вариантов: ");
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
                            Console.Write($"Это не может быть количеством вариантов. Попробуйте ещё раз:");
                        }
                    }
                    while (!ValidValues3);
                    Console.Clear();
                    gen.CreateVariationsFromFile(result2, result3);
                    break;

                case "c":
                    Console.Clear();
                    FormulaSimulator treiner = new FormulaSimulator();
                    treiner.Train();
                    break;


            }

        }
    }
}