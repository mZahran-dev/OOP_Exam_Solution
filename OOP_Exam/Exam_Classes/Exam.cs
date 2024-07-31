using OOP_Exam.Question_Classes;
using System;
using System.Collections.Generic;
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
