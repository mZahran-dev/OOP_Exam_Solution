using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exam_Classes
{
    internal class PracticalExam : Exam
    {
        #region Constructor Chaining
        public PracticalExam(int numberOfQuestion, int examTime) : base(numberOfQuestion, examTime)
        {
        }

        #endregion
        public override void ShowExam()
        {
            Console.Clear();
            double marks = 0;
            if(Questions != null)
            {
                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.WriteLine($"Right Answer for Question {i + 1} => {Questions[i].QuestionAnswers[i]}");
                    marks += Questions[i].QuestionMark;
                }
                Console.WriteLine($"Your Grade is {Grade} out of {marks}");
                Console.WriteLine($"Time = {UserExamTime}");
                Console.WriteLine("Thank You");
            }
            
           
        }


    }
}
