using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            LoadQuestionsFromFile("BankOfQuestions.txt");
        }

        private void LoadQuestionsFromFile(string filename)
        {
            var content = File.ReadAllText(filename).Replace("\r", "");
            var pattern = @"[\d]. (\D+):\n\na\) (.+)\n(Ответ: .+)\n\nb\) (.+)\n(Ответ: .+)\n\nc\) (.+)\n(Ответ: .+)\n\nd\) (.+)\n(Ответ: .+)\n\ne\) (.+)\n(Ответ: .+)\n\n";

            foreach (Match item in Regex.Matches(content, pattern))
            {
                var question = item.Groups[1].Value;
                var answers = new List<string>
                {
                    item.Groups[2].Value,
                    item.Groups[4].Value,
                    item.Groups[6].Value,
                    item.Groups[8].Value,
                    item.Groups[10].Value
                };

                var rightAnswer = item.Groups[3].Value;
                var multipleChoiceTask = new MultipleChoiceTask(question, rightAnswer, answers);
                multipleChoiceTask.ShuffleAnswers();

                _questionBank.Add(multipleChoiceTask);
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
            return task is MultipleChoiceTask mcTask ? mcTask.Hint : task.Hint;
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
                    var randomTaskNumber = random.Next(0, _questionBank.Count);
                    while (_questionHistory.Contains(_questionBank[randomTaskNumber]))
                    {
                        randomTaskNumber = random.Next(0, _questionBank.Count);
                    }

                    var task = _questionBank[randomTaskNumber];
                    _questionHistory.Add(task);

                    File.AppendAllText(filenameVariant, $"{j + 1}. {task}\n");
                    File.AppendAllText(filenameHint, $"{j + 1}. {GiveHelp(task)}\n");
                }
            }
        }
    }
}
