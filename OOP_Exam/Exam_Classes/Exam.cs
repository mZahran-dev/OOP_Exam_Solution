﻿using Microsoft.VisualBasic.FileIO;
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
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Do You Want To Start Exam (Y | N)");
                option = Console.ReadLine().ToLower();

                if (option != "y" && option != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' to start the exam or 'N' to cancel.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (option != "y" && option != "n");

            if (option == "n")
            {
                Console.WriteLine("Exam not started.");
                return;
            }
            if (Questions != null)
            {

                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"{Questions[i].QuestionType} Question\tMark: {Questions[i].QuestionMark}\n");
                    Console.WriteLine($"{Questions[i].QuestionBody}?\n");

                    int answer = 1;
                    bool validAnswer = false;

                    if (Questions[i].QuestionType == "MCQ")
                    {
                       
                        for (int j = 0; j < 3; j++)
                        {                       
                            Console.WriteLine($"{j + 1} - {Questions[i].QuestionAnswers[j].AnswerText}");
                        }

                        while (!validAnswer)
                        {
                            Console.WriteLine("Please Enter The Answer Id (1-3): ");
                            validAnswer = int.TryParse(Console.ReadLine(), out answer) && answer >= 1 && answer <= 3;
                            if (!validAnswer)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid Answer Id (1-3).");
                            }
                        }

                        UserAnswer.Add(Questions[i].QuestionAnswers[answer - 1].AnswerText);

                        if (Questions[i].EvaluteAnswer(answer))
                        {
                            Grade += Questions[i].QuestionMark;
                        }
                    }
                    else
                    {
                        while (!validAnswer)
                        {
                            Console.WriteLine("1 - True");
                            Console.WriteLine("2 - False");
                            Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False): ");
                            validAnswer = int.TryParse(Console.ReadLine(), out answer) && (answer == 1 || answer == 2);
                            if (!validAnswer)
                            {
                                Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                            }
                        }

                        UserAnswer.Add(Questions[i].QuestionAnswers[answer - 1].AnswerText);

                        if (Questions[i].EvaluteAnswer(answer))
                        {
                            Grade += Questions[i].QuestionMark;
                        }
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

        public override string ToString()
        {
            return $"Exam Time : {ExamTime}\nNumber Of Question: {NumberOfQuestion}\nQuestinos : {questions} ";

        }

        #endregion
    }
}
