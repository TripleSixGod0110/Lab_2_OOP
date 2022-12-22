using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class StudentEnumerator : IEnumerable
    {
        private ArrayList testList = new ArrayList();
        private ArrayList examList = new ArrayList();
        public StudentEnumerator(Student student)
        {
            testList = student.TestList;
            examList = student.ExamList;
        }
        public IEnumerator GetEnumerator()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < testList.Count; i++)
            {
                for (int j = 0; j < examList.Count; j++)
                {
                    Test t = (Test)testList[i];
                    Exam e = (Exam)examList[j];
                    if (t.subject == e.subject)
                    {
                        list.Add(t.subject);
                    }
                }
            }
            return list.GetEnumerator();
        }
    }
}
