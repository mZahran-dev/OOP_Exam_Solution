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

        
    }
}
