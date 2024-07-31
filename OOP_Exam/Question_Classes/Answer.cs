using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Question_Classes
{
    internal class Answer
    {
        #region Properties
        private int answerId;
        private string? answerText;
        
        public string? AnswerText
        {
            get { return answerText; }
            set { answerText = value; }
        }
        public int AnswerId
        {
            get { return answerId; }
            set { answerId = value; }
        }
        #endregion

        #region Constructor
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{AnswerText}";
        }
        #endregion

    }
}
