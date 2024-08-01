using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Question_Classes
{
    internal class Question
    {
        #region Properties
        private string? questionType;
        private string? questionBody;
        private double questionMark;
        private List<Answer>? questionAnswers;
        private Answer? correctAnswers;

        public Answer? CorrectAnswers
        {
            get { return correctAnswers; }
            set { correctAnswers = value; }
        }
        public List<Answer>? QuestionAnswers
        {
            get { return questionAnswers; }
            set { questionAnswers = value; }
        }
        public double QuestionMark
        {
            get { return questionMark; }
            set { questionMark = value; }
        }

        public string? QuestionBody
        {
            get { return questionBody; }
            set { questionBody = value; }
        }

        public string? QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }
        #endregion

        #region Constructor
        public Question(string questionBody, double questionMark, List<Answer> questionAnswers, Answer correctAnswers)
        {
            QuestionBody = questionBody;
            QuestionMark = questionMark;
            QuestionAnswers = questionAnswers;
            CorrectAnswers = correctAnswers;
        }

        #endregion

        #region Methods
        public bool EvaluteAnswer(int userAnswerId)
        {
            return CorrectAnswers?.AnswerId == userAnswerId;

        }

        public override string ToString()
        {
            return $"Question Type : {QuestionType}\nQuestion Body: {QuestionBody}\nQuestion Mark: {QuestionMark}\nQuestion Answer: {QuestionAnswers}\nCorrect Answer: {CorrectAnswers}";

        }

        #endregion

    }
}
