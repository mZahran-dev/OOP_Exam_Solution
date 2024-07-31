using OOP_Exam.Question_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exam_Classes
{
    internal abstract class Exam
    {
        #region Properites
        private int examTime;
        private int numberOfQuestion;
        private List<Question>? questions;
        private List<string> userAnswer = new List<string>();
        private int marks;
        private double grade;
        private TimeSpan userExamTime;

        public int ExamTime
        {
            get { return examTime; }
            set { examTime = value; }
        }
        public int NumberOfQuestion
        {
            get { return numberOfQuestion; }
            set { numberOfQuestion = value; }
        }
        public List<Question>? Questions
        {
            get { return questions; }
            set { questions = value; }
        }
        public List<string> UserAnswer
        {
            get { return userAnswer; }
            set { userAnswer = value; }
        }
        public int Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public TimeSpan UserExamTime
        {
            get { return userExamTime; }
            set { userExamTime = value; }
        }

        #endregion

        #region Constructor
        public Exam(int numberOfQuestion, int Etime)
        {
            NumberOfQuestion = numberOfQuestion;
            ExamTime = Etime;
            Questions = new List<Question>();

        }
        #endregion

        #region Methods
        public abstract void ShowExam();
        public void SolveExam()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.Clear();
            Console.WriteLine("Do You Want To Start Exam (Y | N)");
            string option = Console.ReadLine().ToLower();


            for (int i = 0; i < Questions.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"{Questions[i].QuestionType} Question\tMark{Questions[i].QuestionMark}\n");
                Console.WriteLine($"{Questions[i].QuestionBody}?\n");
                if (Questions[i].QuestionType == "MCQ")
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"{j + 1}-{Questions[i].QuestionAnswers[j]}");
                    }
                    Console.WriteLine("Please Enter The Answer Id");
                    int answer = int.Parse(Console.ReadLine());
                    for (int j = 0; j < Questions.Count; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (Questions[j].QuestionAnswers[k].AnswerId == answer)
                            {
                                UserAnswer.Add(Questions[j].QuestionAnswers[k].AnswerText);
                                break;
                            }
                        }

                    }

                    if (Questions[i].EvaluteAnswer(answer))
                    {
                        Grade += Questions[i].QuestionMark;
                    }

                }
                else
                {
                    Console.WriteLine("1-True");
                    Console.WriteLine("2-False");
                    Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False)");
                    int answer = int.Parse(Console.ReadLine());
                    for (int j = 0; j < Questions.Count; j++)
                    {
                        if (Questions[j].QuestionAnswers[j].AnswerId == answer)
                        {
                            UserAnswer.Add(Questions[j].QuestionAnswers[j].AnswerText);
                            break;
                        }
                    }
                    if (Questions[i].EvaluteAnswer(answer))
                    {
                        Grade += Questions[i].QuestionMark;
                    }
                }
            }
            sw.Stop();
            TimeSpan timer = sw.Elapsed;
            UserExamTime = timer;
        }
        public void AddQuestion(Question question)
        {
            if (questions?.Count < NumberOfQuestion)
            {
                questions.Add(question);
            }
            else
            {
                throw new InvalidOperationException("Cannot add more questions than the specified number.");
            }
        }

        #endregion
    }
}
