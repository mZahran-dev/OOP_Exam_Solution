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
            throw new NotImplementedException();
        }


    }
}
