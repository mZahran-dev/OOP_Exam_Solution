using OOP_Exam.Question_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.QuestionFactory
{
    internal static class QuestionFactory
    {
        #region Methods
        public static TrueOrFalseQuestion CreateTrueFalseQuestion()
        {
            Console.WriteLine("True | False Question");

            string? body;
            do
            {
                Console.Write("Enter Question Body: ");
                body = Console.ReadLine();
                if (string.IsNullOrEmpty(body))
                {
                    Console.WriteLine("Question body cannot be empty. Please enter a valid question body.");
                }
            } while (string.IsNullOrEmpty(body));

            double mark;
            while (true)
            {
                Console.Write("Enter Question Mark: ");
                if (double.TryParse(Console.ReadLine(), out mark) && mark > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid positive number for the question mark.");
            }

            var answers = new List<Answer>
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

            int correctAnswerId;
            while (true)
            {
                Console.Write("Enter The Right Answer ID (1 for True, 2 for False): ");
                if (int.TryParse(Console.ReadLine(), out correctAnswerId) && (correctAnswerId == 1 || correctAnswerId == 2))
                {
                    break;
                }
                Console.WriteLine("Please enter 1 for True or 2 for False.");
            }

            Answer correctAnswer = answers.FirstOrDefault(a => a.AnswerId == correctAnswerId)
                                   ?? throw new ArgumentException("Correct answer not found in provided answers.");

            return new TrueOrFalseQuestion(body, mark, answers, correctAnswer);
        }

        public static McqQuestion CreateMcqQuestion()
        {
            Console.WriteLine("MCQ Question");

            string? body;
            do
            {
                Console.Write("Enter Question Body: ");
                body = Console.ReadLine();
                if (string.IsNullOrEmpty(body))
                {
                    Console.WriteLine("Question body cannot be empty. Please enter a valid question body.");
                }
            } while (string.IsNullOrEmpty(body));

            double mark;
            while (true)
            {
                Console.Write("Enter Question Mark: ");
                if (double.TryParse(Console.ReadLine(), out mark) && mark > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid positive number for the question mark.");
            }

            var answers = new List<Answer>();

            Console.WriteLine("Choices Of Question: ");
            for (int i = 0; i < 3; i++)
            {
                string? answerText;
                do
                {
                    Console.WriteLine($"Please Enter Choice Number {i + 1}:");
                    answerText = Console.ReadLine();
                    if (string.IsNullOrEmpty(answerText))
                    {
                        Console.WriteLine("Choice cannot be empty. Please enter a valid choice.");
                    }
                } while (string.IsNullOrEmpty(answerText));

                answers.Add(new Answer(i + 1, answerText));
            }

            int correctAnswerId;
            while (true)
            {
                Console.Write("Enter the right Answer Id: ");
                if (int.TryParse(Console.ReadLine(), out correctAnswerId) && correctAnswerId >= 1 && correctAnswerId <= 3)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid Answer Id (1-3).");
            }

            Answer correctAnswer = answers.FirstOrDefault(a => a.AnswerId == correctAnswerId)
                                   ?? throw new ArgumentException("Correct answer not found in provided answers.");

            return new McqQuestion(body, mark, answers, correctAnswer);

        }

        #endregion


    }
}
