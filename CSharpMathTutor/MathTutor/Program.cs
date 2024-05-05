using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MathTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gen = new Generator();
            Console.WriteLine("Выберете 1 ил 2 и напишите число:           (1) Вывести банк вопросов              (2) Создать контрольную работу");
            var answ = Console.ReadLine();
            if (answ != null)
            {
                if (answ == "1")
                    gen.PrintQuestionBank();
                if (answ == "2")
                {
                    Console.WriteLine("Введите количество вариантов в контрольной: ");
                    var numberOfVariants = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество заданий в варианте: ");
                    var numberOfTasks = int.Parse(Console.ReadLine());
                    gen.CreateVariationsFromFile(numberOfVariants, numberOfTasks);
                    Console.WriteLine("Контрольная сохранилась");
                }
            }
        }
    }
}