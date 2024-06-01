using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MathTutor
{
    // Класс для задания контрольной
    public class Task
    {
        public string Question { get; private set; }
        public string RightAnswer { get; private set; }
        public string Hint { get; private set; }

        public Task(string question, string rightAnswer)
        {
            Question = question;
            RightAnswer = rightAnswer;
            Hint = Regex.Replace(RightAnswer, @"\d+", "# ");
        }

        public override string ToString()
        {
            return $"{Question}\n{RightAnswer}\n";
        }
    }

    // Класс для задания с выбором ответа
    public class MultipleChoiceTask : Task
    {
        public List<string> Answers { get; private set; }

        public MultipleChoiceTask(string question, string rightAnswer, List<string> answers)
            : base(question, rightAnswer)
        {
            Answers = answers;
            Hint = GetRandomIncorrectAnswer();
        }

        private string GetRandomIncorrectAnswer()
        {
            var incorrectAnswers = Answers.Where(a => a != RightAnswer).ToList();
            var random = new Random();
            return incorrectAnswers[random.Next(incorrectAnswers.Count)];
        }

        public void ShuffleAnswers()
        {
            var random = new Random();
            Answers = Answers.OrderBy(a => random.Next()).ToList();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Question);
            foreach (var answer in Answers)
            {
                sb.AppendLine(answer);
            }
            return sb.ToString();
        }
    }
}
