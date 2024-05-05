using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class Formula
    {
        public string Name { get; private set; }
        public string RightAnswer { get; private set; }

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