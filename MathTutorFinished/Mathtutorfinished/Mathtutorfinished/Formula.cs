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
    public class Theorem
    {
        public string Condition { get; private set; }
        public string Conclusion { get; private set; }
        public string Proof { get; private set; }

        public Theorem(string condition, string conclusion, string proof)
        {
            Condition = condition;
            Conclusion = conclusion;
            Proof = proof;
        }

        public override string ToString()
        {
            return $"Условие = {Condition}\nЗаключение = {Conclusion}\nДоказательство = {Proof}";
        }
    }

    public class Training
    {
        private List<Formula> formulas = new List<Formula>();
        private List<Theorem> theorems = new List<Theorem>();
        private Dictionary<string, int> incorrectAnswers = new Dictionary<string, int>();

        public void LoadFromFile(string filename)
        {

            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts[0] == "Formula")
                {
                    var formula = new Formula(parts[1], parts[2]);
                    formulas.Add(formula);
                }
                else if (parts[0] == "Theorem")
                {
                    var theorem = new Theorem(parts[1], parts[2], parts[3]);
                    theorems.Add(theorem);
                }
            }
        }

        public void StartTraining(string topic)
        {
            if (topic == "Formula")
            {
                foreach (var formula in formulas)
                {
                    Console.WriteLine($"Назовите формулу для {formula.Name}");
                    var answer = Console.ReadLine();
                    if (answer == formula.RightAnswer)
                    {
                        Console.WriteLine("Правильно!");
                    }
                    else
                    {
                        Console.WriteLine($"Неправильно. Правильный ответ: {formula.RightAnswer}");
                        RecordIncorrectAnswer(formula.Name);
                    }
                }
            }
            else if (topic == "Theorem")
            {
                foreach (var theorem in theorems)
                {
                    Console.WriteLine($"Назовите условие для теоремы: ");
                    var conditionAnswer = Console.ReadLine();
                    if (conditionAnswer == theorem.Condition)
                    {
                        Console.WriteLine("Правильно! Назовите заключение:");
                        var conclusionAnswer = Console.ReadLine();
                        if (conclusionAnswer == theorem.Conclusion)
                        {
                            Console.WriteLine("Правильно! Назовите доказательство:");
                            var proofAnswer = Console.ReadLine();
                            if (proofAnswer == theorem.Proof)
                            {
                                Console.WriteLine("Правильно!");
                            }
                            else
                            {
                                Console.WriteLine($"Неправильно. Правильное доказательство: {theorem.Proof}");
                                RecordIncorrectAnswer(theorem.Condition);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Неправильно. Правильное заключение: {theorem.Conclusion}");
                            RecordIncorrectAnswer(theorem.Condition);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Неправильно. Правильное условие: {theorem.Condition}");
                        RecordIncorrectAnswer(theorem.Condition);
                    }
                }
            }
        }

        private void RecordIncorrectAnswer(string name)
        {
            if (incorrectAnswers.ContainsKey(name))
            {
                incorrectAnswers[name]++;
            }
            else
            {
                incorrectAnswers[name] = 1;
            }
        }

        public void ShowStatistics(int numberOfTrainings)
        {
            Console.WriteLine("Статистика неправильных ответов:");
            foreach (var entry in incorrectAnswers.OrderByDescending(kv => kv.Value).Take(numberOfTrainings))
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} неправильных ответов");
            }
        }

        public void ShowShortestFormulaAndLongestTheorem()
        {
            var shortestFormula = formulas.OrderBy(f => f.RightAnswer.Length).FirstOrDefault();
            var longestTheorem = theorems.OrderByDescending(t => t.Proof.Length).FirstOrDefault();

            if (shortestFormula != null)
            {
                Console.WriteLine($"Формула с самой короткой записью: {shortestFormula.Name} - {shortestFormula.RightAnswer}");
            }
            if (longestTheorem != null)
            {
                Console.WriteLine($"Теорема с самым длинным доказательством: {longestTheorem.Condition} - {longestTheorem.Proof}");
            }
        }
    }

}