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
            Console.Write("Enter Question Body: ");
            string? body = Console.ReadLine();
            Console.Write("Enter Question Mark: ");
            double mark = double.Parse(Console.ReadLine());

            var answers = new List<Answer>
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

            Console.Write("Enter The right Answer ID (1 for True, 2 for False): ");
            int? correctAnswerId = int.Parse(Console.ReadLine());

            Answer? correctAnswer = null;
            foreach (var answer in answers)
            {
                if (answer.AnswerId == correctAnswerId)
                {
                    correctAnswer = answer;
                    break;
                }
            }
            if (correctAnswer == null)
            {
                throw new ArgumentException("Correct answer not found in provided answers.");
            }



            return new TrueOrFalseQuestion(body, mark, answers, correctAnswer);

        }

        public static McqQuestion CreateMcqQuestion()
        {
            Console.WriteLine("MCQ Question");
            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Question Mark: ");
            double mark = double.Parse(Console.ReadLine());

            var answers = new List<Answer>();

            Console.WriteLine("Choices Of Question: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Please Enter Choice Number {i + 1}");
                string answerText = Console.ReadLine();
                answers.Add(new Answer(i + 1, answerText));
            }
            Console.WriteLine("Enter the right Answer Id: ");
            int correctAnswerId = int.Parse(Console.ReadLine());

            Answer correctAnswer = null;
            foreach (var answer in answers)
            {
                if (answer.AnswerId == correctAnswerId)
                {
                    correctAnswer = answer;
                    break;
                }
            }
            return new McqQuestion(body, mark, answers, correctAnswer);

        }

        #endregion


    }
}
