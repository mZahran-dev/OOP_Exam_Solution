using OOP_Exam.Exam_Classes;
using OOP_Exam.SubjectClass;

namespace OOP_Exam
{
    internal class Program
    {
        static int GetValidInput(string prompt, Func<int, bool> validate)
        {
            int value;
            bool validInput;
            do
            {
                Console.WriteLine(prompt);
                validInput = int.TryParse(Console.ReadLine(), out value) && validate(value);
                if (!validInput)
                {
                    Console.WriteLine("Enter a valid value.");
                }
            } while (!validInput);
            return value;
        }
        static void Main(string[] args)
        {
            bool flag = false;
            string? subjectName;
            Subject? subject = null;
            do
            {
                int subjectId;
                Console.Write("Enter Subject Id: ");
                flag = int.TryParse(Console.ReadLine(), out subjectId);
                Console.Write("Enter Subject Name: ");
                subjectName = Console.ReadLine();

                if (flag && !string.IsNullOrEmpty(subjectName))
                {
                    subject = new Subject
                    {
                        SubjectId = subjectId,
                        SubjectName = subjectName
                    };
                }
                else
                {
                    Console.WriteLine("Enter Valid Data");
                    flag = false;
                }

            } while (!flag);


            Console.Clear();
            int examType = GetValidInput("Enter The Type of Exam (1 For Practical | 2 For Final)", x => x == 1 || x == 2);
            int examTime = GetValidInput("Enter the time for exam (30 min to 180 min)", x => x >= 30 && x <= 180);
            int noQuestions = GetValidInput("Enter the number of Questions", x => x > 0);

            if (examType == 1)
            {
                PracticalExam practicalExam = new PracticalExam(noQuestions, examTime);
                for (int i = 0; i < noQuestions; i++)
                {
                    Console.Clear();
                    var answer = QuestionFactory.QuestionFactory.CreateMcqQuestion();
                    practicalExam.AddQuestion(answer);
                }
                subject?.CreateExam(practicalExam);
                practicalExam.SolveExam();
                practicalExam.ShowExam();
            }
            else if (examType == 2)
            {
                FinalExam finalExam = new FinalExam(noQuestions, examTime);
                for (int i = 0; i < noQuestions; i++)
                {
                    Console.Clear();
                    int questionType = GetValidInput("Enter The Type of Question (1 For MCQ | 2 For True/False)", x => x == 1 || x == 2);
                    if (questionType == 1)
                    {
                        Console.Clear();
                        var answer = QuestionFactory.QuestionFactory.CreateMcqQuestion();
                        finalExam.AddQuestion(answer);
                    }
                    else if (questionType == 2)
                    {
                        Console.Clear();
                        var answer = QuestionFactory.QuestionFactory.CreateTrueFalseQuestion();
                        finalExam.AddQuestion(answer);
                    }
                }
                subject?.CreateExam(finalExam);
                finalExam.SolveExam();
                finalExam.ShowExam();
            }


        }

    }
}
