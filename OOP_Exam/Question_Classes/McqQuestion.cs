using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Question_Classes
{
    internal class McqQuestion : Question
    {
        #region Constructor
        public McqQuestion(string questionBody, double questionMark, List<Answer> questionAnswers, Answer correctAnswers)
           : base(questionBody, questionMark, questionAnswers, correctAnswers)
        {
            QuestionType = "MCQ";
        }
        #endregion
    }
}
