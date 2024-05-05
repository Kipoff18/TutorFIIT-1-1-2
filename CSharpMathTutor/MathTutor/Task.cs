
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
}