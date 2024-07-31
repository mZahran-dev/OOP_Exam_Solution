using OOP_Exam.Exam_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.SubjectClass
{
    internal class Subject
    {
        #region Propeties
        private int subjectId;
        private string? subjectName;
        private Exam? subjectExam;

        public Exam? SubjectExam
        {
            get { return subjectExam; }
            set { subjectExam = value; }
        }

        public string? SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        #endregion Propeties

        #region Methods
        public void CreateExam(Exam exam)
        {
            subjectExam = exam;
        }
        public override string ToString()
        {
            return $"SubjectId: {SubjectId}, SubjectName: {SubjectName}, Exam: {SubjectExam}";
        }
        #endregion
    }
}
