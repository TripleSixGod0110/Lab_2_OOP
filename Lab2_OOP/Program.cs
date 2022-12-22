using System;
using System.Collections.Generic;

namespace Lab2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine("--- Проверка равенства 2 объектов типа Person c совпадающими данными---\n");
            Person p_1 = new Person();
            Person p_2 = new Person();

            Console.WriteLine("Объекты равны: " + Equals(p_1, p_2));
            Console.WriteLine("Ссылки равны: " + ReferenceEquals(p_1, p_2));
            Console.WriteLine("Hash Code p_1: " + p_1.GetHashCode());
            Console.WriteLine("Hash Code p_2: " + p_2.GetHashCode());

            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine("---  Данные---\n");
            Student student = new Student();
            student.personalData = new Person();
            student.formOfEducation = Education.Bachelor;
            student.groupNumber = 126;
            Console.WriteLine(student.ToShortString());

            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine("--- Список экзаменов и зачётов ---\n");
            Console.WriteLine(student.ToString());
            student.AddExams(new Exam(), new Exam("Матан.", 5, new DateTime(2022, 12, 30)));

            student.AddExams(new Exam("Физ-ра", 3, new DateTime(2022, 12, 30)));

            student.AddExams(new Exam("ИИ", 4, new DateTime(2022, 12, 27)));

            student.AddTests(new Test(), new Test("ИИ", true), new Test("English", false));


            Console.WriteLine(student.ToString());

            Console.WriteLine(student.personalData.ToString());



            Student CopyStudent = (Student)student.DeepCopy();
            student.groupNumber = 301;
            student.ExamList.Add(new Exam())
                ;
            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine("--- Вывод копии---\n");
            Console.WriteLine(CopyStudent.ToString());
            Console.WriteLine("\n\n--------------------------------------------");
            
            Console.WriteLine("--- Вывод данных с изменённой групппой---\n");
            Console.WriteLine(student.ToString());
            Console.WriteLine("\n\n--------------------------------------------");
            
            
            Console.WriteLine("--- Исключение ---\n");
            try
            {
                student.groupNumber = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n\n--------------------------------------------");
            
            
            
            Console.WriteLine("--- Список всех экзаменов и зачётов ---\n");
            foreach (var ExamOrTest in student.GetExamsAndTests())
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n--------------------------------------------");
            
            
            Console.WriteLine("--- Экзамены, оценки на которые больше 3 ---\n");
            foreach (var ExamOrTest in student.GetExams(3))
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n--------------------------------------------");
            
            
            Console.WriteLine("--- Предметы, которые есть как в списке зачетов и экзаменов ---\n");
            StudentEnumerator studentEnumerator = new StudentEnumerator(student);
            foreach (object item in studentEnumerator)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n--------------------------------------------");
           
            
            Console.WriteLine("--- Все сданные зачеты и экзамены ---\n");
            foreach (var ExamOrTest in student.PassedExamsAndTests())
            {
                Console.WriteLine(ExamOrTest.ToString());
            }

            Console.WriteLine("\n\n--------------------------------------------");
            
            
            Console.WriteLine("--- Сданные зачеты и экзамены ---\n");
            foreach (var Test in student.PassedTestsWithExams())
            {
                Console.WriteLine(Test.ToString());
            }

            Console.WriteLine("\n\n--------------------------------------------");
        }
    }
}


