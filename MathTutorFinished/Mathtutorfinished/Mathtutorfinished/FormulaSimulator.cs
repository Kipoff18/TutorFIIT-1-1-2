using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace MathTutor
{
    public class FormulaSimulator
    {

        public Dictionary<string, List<Formula>> FormulaBank { get; private set; }
        public int RightAnswers { get; set; }
        public Dictionary<string, List<Formula>> WrongAnswers { get; private set; }

        public FormulaSimulator()
        {
            FormulaBank = new Dictionary<string, List<Formula>>();
            RightAnswers = 0;
            WrongAnswers = new Dictionary<string, List<Formula>>();
        }

        public override string ToString()
        {
            return $"Неправильных ответов = {WrongAnswers}\nПравильных ответов = {RightAnswers}";
        }


        /// <summary>
        /// Возвращает массив строк из файла
        /// </summary>
        /// <param name="bank">Исходный файл</param>
        /// <returns></returns>
        private static string[] ReadingAndParsingFile(string bank)
        {
            string[] ss = File.ReadAllLines(bank, Encoding.UTF8);
            Console.OutputEncoding = Encoding.UTF8;
            return ss;
        }


        /// <summary>
        /// Получает тему из данной строки
        /// </summary>
        /// <param name="text">Данная строка</param>
        /// <returns></returns>
        private static string SelectionOfTopic(string text)
        {
            var s = Regex.Split(text, @"\|");
            string topic = s[0];

            return topic;
        }


        /// <summary>
        /// Получает формулу из данной строки
        /// </summary>
        /// <param name="text">Данная строка</param>
        /// <returns></returns>
        private static string SelectionOfFormulas(string text)
        {
            var s = Regex.Split(text, @"\|");
            string formula = s[1];

            return formula;
        }


        /// <summary>
        /// Получает название формулы из данной строки
        /// </summary>
        /// <param name="text">Данная строка</param>
        /// <returns></returns>
        private static string SelectionOfNameFormulas(string text)
        {
            var s = Regex.Split(text, @"\|");
            string nameFormula = s[2];

            return nameFormula;
        }


        /// <summary>
        /// Выводит приветствие
        /// </summary>
        private static void PrintHello()
        {
            Console.WriteLine("======= РАДЫ ПРИВЕТСТВОВАТЬ ВАС В НАШЕМ ТРЕНАЖЁРЕ ФОРМУЛ =======");
        }


        /// <summary>
        /// Выводит список тем для формул
        /// </summary>
        private static void ChoosingTopics()
        {
            Console.WriteLine("Темы доступные в тестировании");
            Console.WriteLine("1. Тригонометрия      2. Формулы сокращённого умножения");
        }


        /// <summary>
        /// Обработка ответа пользователя
        /// </summary>
        /// <returns></returns>
        private static string UserResponse()
        {
            string playerAnswer;
            string result;
            bool ValidValues = false;
            do
            {
                playerAnswer = Console.ReadLine();
                if (playerAnswer.ToLower() == "да" || playerAnswer.ToLower() == "нет")
                {
                    ValidValues = true;
                }

                result = playerAnswer;

                if (!ValidValues)
                {
                    Console.Write($"Это не может быть ответом на вопрос. Попробуйте ещё раз:");
                }
            }
            while (!ValidValues);

            return result;
        }


        /// <summary>
        /// Обработка выбора темы 
        /// </summary>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        private static string[] UserChoiceOfTopic(int arraySize)
        {
            string playerAnswer;
            string[] result = new string[arraySize];
            bool ValidValues = false;

            for (var i = 0; i < result.Length; i++)
            {
                do
                {
                    playerAnswer = Console.ReadLine().ToLower().Trim();
                    if (playerAnswer == "формулы сокращённого умножения" || playerAnswer == "тригонометрия" || playerAnswer == "формулы сокращенного умножения")
                    {
                        ValidValues = true;
                    }

                    result[i] = playerAnswer;

                    if (!ValidValues)
                    {
                        Console.Write($"Это не может быть темой. Попробуйте ещё раз:");
                    }
                }
                while (!ValidValues);
            }

            return result;
        }


        /// <summary>
        /// Обработка выбора темы для статистики
        /// </summary>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        private static string UserChoiceOfTopicForStatic()
        {
            string playerAnswer;
            string result;
            bool ValidValues = false;

            do
            {
                playerAnswer = Console.ReadLine().ToLower().Trim();
                if (playerAnswer == "формулы сокращённого умножения" || playerAnswer == "тригонометрия" || playerAnswer == "формулы сокращенного умножения")
                {
                    ValidValues = true;
                }

                result = playerAnswer;

                if (!ValidValues)
                {
                    Console.Write($"Это не может быть темой. Попробуйте ещё раз:");
                }
            }
            while (!ValidValues);


            return result;
        }


        /// <summary>
        /// Выбор количества тем
        /// </summary>
        /// <returns></returns>
        private static string UserChoiceOfCountTopic()
        {
            string playerAnswer;
            string result;
            bool ValidValues = false;
            do
            {
                playerAnswer = Console.ReadLine();
                if (playerAnswer.ToLower() == "1" || playerAnswer.ToLower() == "2")
                {
                    ValidValues = true;
                }

                result = playerAnswer;

                if (!ValidValues)
                {
                    Console.Write($"Это не может быть количеством тем. Попробуйте ещё раз:");
                }
            }
            while (!ValidValues);

            return result;
        }


        /// <summary>
        /// Запись в поле
        /// </summary>
        /// <param name="ss"></param>
        private void FormulaBankСompletion(string[] ss)
        {
            for (var i = 0; i < ss.Length; i++)
            {
                if (ss[i] != null)
                {
                    string[] TopicFormulaName = Regex.Split(ss[i], @"\|");
                    string topic = TopicFormulaName[0].ToLower().Trim();
                    Formula formula = new Formula(TopicFormulaName[1], TopicFormulaName[2]);

                    if (FormulaBank.ContainsKey(topic))
                    {
                        FormulaBank[topic].Add(formula);
                    }
                    else
                    {
                        FormulaBank.Add(topic, new List<Formula> { formula });
                    }
                }
            }
        }


        /// <summary>
        /// Выбор количества тем для статистики
        /// </summary>
        /// <returns></returns>
        private static int UserChoiceOfCountTreins(int maxTreinCount)
        {
            int playerAnswer;
            int result;
            bool ValidValues = false;
            do
            {
                ValidValues = int.TryParse(Console.ReadLine(), out playerAnswer) && (playerAnswer >= 0 && playerAnswer <= maxTreinCount);


                result = playerAnswer;

                if (!ValidValues)
                {
                    Console.Write($"Это не может быть количеством тренировок. Попробуйте ещё раз:");
                }
            }
            while (!ValidValues);

            return result;
        }


        /// <summary>
        /// Создаёт или записывает в файл статистики
        /// </summary>
        private void AddingToTheStatisticsFile()
        {
            var treinNumber = 0;
            try
            {

                if (File.ReadAllLines("Statistic.txt", Encoding.UTF8).Count() == 0)
                {
                    treinNumber = 0;
                }
                else
                {
                    treinNumber = int.Parse(Regex.Split(File.ReadAllLines("Statistic.txt", Encoding.UTF8).Last(), @"\|")[0]);
                }
            }
            catch (FileNotFoundException) { treinNumber = 0; }

            foreach (var topic in WrongAnswers.Keys)
            {
                using (var sw = new StreamWriter(File.Open("Statistic.txt", FileMode.Append)))
                {
                    sw.WriteLine($"{treinNumber + 1} | {topic} | {WrongAnswers[topic].Count}");
                }
            }
        }


        /// <summary>
        /// Печатает статистику
        /// </summary>
        /// <param name="topicForStatic"></param>
        /// <param name="countOfTreinsStatic"></param>
        /// <param name="maxTreinsCount"></param>
        /// <param name="statisticFile"></param>
        private void PrintStatistic(string topicForStatic, int countOfTreinsStatic, int maxTreinsCount, string[] statisticFile)
        {
            Console.WriteLine($"======= Статистика по теме {topicForStatic} по последним {countOfTreinsStatic} тренировкам =======");

            int countWrongAnswers = 0;
            for (var i = maxTreinsCount; i > (maxTreinsCount - countOfTreinsStatic); i--)
            {
                for (var j = statisticFile.Length - 1; j >= 0; j--)
                {
                    var s = Regex.Split(statisticFile[j], @"\|");
                    if (int.Parse(s[0].Trim()) == i && s[1].Trim() == topicForStatic) { countWrongAnswers += int.Parse(s[2].Trim()); }
                }
            }
            Console.WriteLine($"Количество неправильных ответов ---> {countWrongAnswers}");
        }


        /// <summary>
        /// Ход тренировки
        /// </summary>
        public void Train()
        {
            var ss = ReadingAndParsingFile("./input-files/test.txt"); //распарсенный файл
            FormulaBankСompletion(ss);
            string formula;
            string nameFormula;
            string topic;

            PrintHello();
            ChoosingTopics();
            Console.Write("Введите количество тем, которые будут участвовать в тренировке: ");
            string choosingCount = UserChoiceOfCountTopic();
            Console.WriteLine("Введите названия тем, которые будут участвовать в тренировке: ");
            string[] choosingTopic = UserChoiceOfTopic(int.Parse(choosingCount));
            Console.Clear();


            foreach (var theme in choosingTopic)
            {
                WrongAnswers[theme] = new List<Formula>();
                var formulas = FormulaBank[theme];
                for (var i = 0; i < formulas.Count; i++)
                {
                    var rightAnswer = false;
                    while (rightAnswer == false)
                    {
                        Console.WriteLine(formulas[i].RightAnswer);
                        Console.WriteLine("Для продолжения нажмите Enter");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                        Console.WriteLine($"Правильный ответ -> {formulas[i].Name}");
                        //Thread.Sleep(5000);
                        Console.Clear();

                        Console.WriteLine("Вы дали правильный ответ? (да/нет)");
                        string answer = UserResponse();
                        if (answer.ToString().ToLower() == "да")
                        {
                            rightAnswer = true;
                            Console.WriteLine("Отлично! Продолжайте в том же духе!");
                            //Thread.Sleep(2000);
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            if (!WrongAnswers[theme].Contains(formulas[i]))
                            {
                                if (WrongAnswers.ContainsKey(theme))
                                {
                                    WrongAnswers[theme].Add(formulas[i]);
                                }
                                else
                                {
                                    WrongAnswers.Add(theme, new List<Formula> { formulas[i] });
                                }

                            }

                            Console.WriteLine("Ничего страшного, давайте попробуем ещё раз");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                }
            }
            AddingToTheStatisticsFile();

            Console.WriteLine("Введите название темы, по которой нужно вывести статистику: ");
            Console.WriteLine("1. Тригонометрия      2. Формулы сокращённого умножения");
            var topicForStatic = UserChoiceOfTopicForStatic();
            Console.WriteLine("Теперь введите количество учитываемых тренировок: ");

            string[] statisticFile = File.ReadAllLines("Statistic.txt", Encoding.UTF8);
            int maxTreinCount;
            if (int.Parse(choosingCount) > 1)
            {
                maxTreinCount = int.Parse(Regex.Split(statisticFile.Last(), @"\|")[0]) - (int.Parse(choosingCount) - 1);
            }
            else { maxTreinCount = int.Parse(Regex.Split(statisticFile.Last(), @"\|")[0]); }

            var countOfTreinsStatic = UserChoiceOfCountTreins(maxTreinCount);

            PrintStatistic(topicForStatic, countOfTreinsStatic, maxTreinCount, statisticFile);
        }


    }
}