using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class Formula
    {
        public string Name { get; set; }
        public string RightAnswer { get; set; }

        public Formula(string name, string rightAnswer)
        {
            Name = name;
            RightAnswer = rightAnswer;
        }

        public override string ToString()
        {
            return $"Название формулы = {Name}\nПравильный ответ = {RightAnswer}";
        }
    }

}