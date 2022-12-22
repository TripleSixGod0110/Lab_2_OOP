using System;
using System.Collections.Generic;

namespace Lab2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Проверка равенства 2 объектов типа Person c совпадающими данными, проверка того, что ссылки на объекты не равны, а объекты равны и вывод значений хэш кодов---\n");
            Person p1 = new Person();
            Person p2 = new Person();

            Console.WriteLine("Объекты равны: " + Equals(p1, p2));
            Console.WriteLine("Ссылки равны: " + ReferenceEquals(p1, p2));
            Console.WriteLine("Hash Code p1: " + p1.GetHashCode());
            Console.WriteLine("Hash Code p2: " + p2.GetHashCode());

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Персональные данные---\n");
            Student student = new Student();
            student.personalData = new Person();
            student.formOfEducation = Education.Bachelor;
            student.groupNumber = 300;
            Console.WriteLine(student.ToShortString());

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Список экзаменов и зачётов ---\n");
            Console.WriteLine(student.ToString());
            student.AddExams(new Exam(), new Exam("Математический анализ", 5, new DateTime(2022, 12, 12)));
            student.AddExams(new Exam("Физическая культура", 3, new DateTime(2022, 12, 12)));
            student.AddExams(new Exam("Искусственный интеллект", 4, new DateTime(2022, 12, 12)));
            student.AddTests(new Test(), new Test("Искусственный интеллект", true), new Test("English", false));
            Console.WriteLine(student.ToString());

            Console.WriteLine(student.personalData.ToString());


            Student CopyStudent = (Student)student.DeepCopy();
            student.groupNumber = 301;
            student.ExamList.Add(new Exam());
            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Вывод копии---\n");
            Console.WriteLine(CopyStudent.ToString());
            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Вывод данных с изменённой групппой---\n");
            Console.WriteLine(student.ToString());

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Исключение ---\n");
            try
            {
                student.groupNumber = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Список всех экзаменов и зачётов ---\n");
            foreach (var ExamOrTest in student.GetExamsAndTests())
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Экзамены, оценки на которые больше 3 ---\n");
            foreach (var ExamOrTest in student.GetExams(3))
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Предметы, которые есть как в списке зачетов, так и в списке экзаменов ---\n");
            StudentEnumerator studentEnumerator = new StudentEnumerator(student);
            foreach (object item in studentEnumerator)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Все сданные зачеты и экзамены ---\n");
            foreach (var ExamOrTest in student.PassedExamsAndTests())
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n==============================================");
            Console.WriteLine("--- Сданные зачеты, для которых сдан и экзамен ---\n");
            foreach (var Test in student.PassedTestsWithExams())
            {
                Console.WriteLine(Test.ToString());
            }

            Console.WriteLine("\n\n==============================================");
        }
    }
}


