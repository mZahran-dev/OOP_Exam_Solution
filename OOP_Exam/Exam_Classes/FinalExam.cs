using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exam_Classes
{
    internal class FinalExam : Exam
    {
        #region Constructor Chaining
        public FinalExam(int numberOfQuestion, int examTime) : base(numberOfQuestion, examTime)
        {
        }
        #endregion

        public override void ShowExam()
        {
            Console.Clear();
            double marks = 0;
            if (Questions != null)
            {
                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.WriteLine($"Question {i + 1} : {Questions[i].QuestionBody}");
                    Console.WriteLine($"Your Answer => {UserAnswer[i]}");

                    Console.WriteLine($"Right Answer => {Questions[i].CorrectAnswers}");
                    
                    marks += Questions[i].QuestionMark;
                }
                Console.WriteLine($"Your Grade is {Grade} out of {marks}");
                Console.WriteLine($"Time = {UserExamTime}");
                Console.WriteLine("Thank You");
            }
           
        }

    }
}
