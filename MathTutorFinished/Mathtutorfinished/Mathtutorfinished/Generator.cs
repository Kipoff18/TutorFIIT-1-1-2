using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathTutor
{
    public class Generator
    {
        private List<Task> _questionBank;
        private List<Task> _questionHistory;
        public Generator()
        {
            _questionBank = new List<Task>();
            _questionHistory = new List<Task>();
            var pattern = @"[\d]. (\D+):\n\na\) (.+)\n(Ответ: .+)\n\nb\) (.+)\n(Ответ: .+)\n\nc\) (.+)\n(Ответ: .+)\n\nd\) (.+)\n(Ответ: .+)\n\ne\) (.+)\n(Ответ: .+)\n\n";
            foreach (Match item in Regex.Matches(File.ReadAllText("BankOfQuestions.txt").Replace("\r", ""), pattern))
            {
                _questionBank.Add(new Task(item.Groups[2].Value, item.Groups[3].Value));
                _questionBank.Add(new Task(item.Groups[4].Value, item.Groups[5].Value));
                _questionBank.Add(new Task(item.Groups[6].Value, item.Groups[7].Value));
                _questionBank.Add(new Task(item.Groups[8].Value, item.Groups[9].Value));
                _questionBank.Add(new Task(item.Groups[10].Value, item.Groups[11].Value));
            }
        }
        public void PrintQuestionBank()
        {
            foreach (var item in _questionBank)
            {
                Console.WriteLine(item);
            }
        }

        private string GiveHelp(Task task)
        {
            return task.Hint;
        }
        public void CreateVariationsFromFile(int numberOfVariants, int numberOfTasks)
        {
            while (numberOfTasks > 50)
            {
                Console.WriteLine("Значение количества заданий слишком большое, введите меньше:");
                numberOfTasks = int.Parse(Console.ReadLine());
            }
            while (numberOfTasks * numberOfVariants > 50)
            {
                Console.WriteLine("Значение количества вариантов слишком большое, введите меньше:");
                numberOfVariants = int.Parse(Console.ReadLine());
            }
            var random = new Random();
            for (int i = 0; i < numberOfVariants; i++)
            {
                var filenameVariant = $"Вариант №{i + 1}.txt";
                var filenameHint = $"Подсказки к варианту №{i + 1}.txt";
                for (int j = 0; j < numberOfTasks; j++)
                {
                    var randomTaskNumber = random.Next(0, 50);
                    while (_questionHistory.Contains(_questionBank[randomTaskNumber]))
                    {
                        randomTaskNumber = random.Next(0, 50);
                    }
                    File.AppendAllText(filenameVariant, $"{j + 1}. {_questionBank[randomTaskNumber].Question}\n");
                    File.AppendAllText(filenameHint, $"{j + 1}. {GiveHelp(_questionBank[randomTaskNumber])}\n");
                }
            }
        }
    }
}