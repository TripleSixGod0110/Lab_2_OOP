using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class Exam
    {
        public string subject { get; set; }
        public int grade { get; set; }
        public DateTime examDate { get; set; }
        public Exam(string studentSubject, int studentGrade, DateTime studentExamDate)
        {
            this.subject = studentSubject;
            this.grade = studentGrade;
            this.examDate = studentExamDate;
        }
        public Exam()
        {
            this.subject = "English";
            this.grade = 4;
            this.examDate = new DateTime(2022, 01, 01);
        }
        public override string ToString()
        {
            return "Предмет: " + subject + "; Оценка: " + grade + "; Дата экзамена: " + examDate.ToString();
        }
        interface IDateANdCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }
    }
}
