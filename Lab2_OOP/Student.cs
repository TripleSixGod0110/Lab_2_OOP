using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Lab2_OOP
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }

    class Student : Person
    {
        public Person personalData
        {
            get
            {
                return new Person(name, surname, birthDate);
            }
            set
            {
                name = value.Name;
                surname = value.Surname;
                birthDate = value.BirthDate;
            }
        }
        public Education formOfEducation { get; set; }
        public int groupNumber
        {
            get
            {
                return groupNumberField;
            }
            set
            {
                if ((value <= 100) || (value > 599))
                {
                    throw new Exception("Значение должно быть больше 100 и меньше 599");
                }
                groupNumberField = value;
            }
        }
        public virtual int Count { get; }
        public ArrayList TestList { get { return testList; } }
        public ArrayList ExamList { get { return examList; } }

        private Education formOfEducationField;
        private int groupNumberField;
        private ArrayList testList = new ArrayList();
        private ArrayList examList = new ArrayList();
        public Student(Person studentPersonalData, Education studentFormOfEducationField, int studentGroupNumberField)
        {
            this.personalData = studentPersonalData;
            this.formOfEducationField = studentFormOfEducationField;
            this.groupNumberField = studentGroupNumberField;
        }
        public Student()
        {
            this.personalData = new Person();
            this.formOfEducationField = Education.Bachelor;
            this.groupNumberField = 14;
        }
        private Double average
        {
            get
            {
                int sum = 0;
                int quantity = 0;
                for (int i = 0; i < examList.Count; i++)
                {
                    Exam ex = (Exam)examList[i];
                    sum += ex.grade;
                    quantity++;
                }
                if (quantity > 0)
                {
                    return sum / quantity;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool this[Education indexer]
        {
            get { return indexer == formOfEducation; }
        }

        public override string ToString()
        {
            String result = "Персональные данные: " + personalData + "\n" + "Форма обучения: " + formOfEducationField + "\n" + "Номер группы: " + groupNumberField + "\n" + "Список экзаменов: ";
            for (int i = 0; i < examList.Count; i++)
            {
                result = result + " " + examList[i].ToString();
            }
            return result;
            String result2 = "Зачёты: ";
            for (int i = 0; i < testList.Count; i++)
            {
                result = result + " " + testList[i].ToString();
            }
            return result2;
        }
        public virtual string ToShortString()
        {
            return "Персональные данные: " + personalData + "\n" + "Форма обучения: " + formOfEducationField + "\n" + "Номер группы: " + groupNumberField + "\n" + "Средний балл: " + average + "\n";
        }
        public void AddExams(params Exam[] list)
        {
            int originalLength = examList.Count;
            for (int i = 0; i < list.Length; i++)
            {
                examList.Add(list[i]);
            }
        }
        public void AddTests(params Test[] list)
        {
            int originalLength = testList.Count;
            for (int i = 0; i < list.Length; i++)
            {
                testList.Add(list[i]);
            }
        }
        public override object DeepCopy()
        {
            Student other = (Student)this.MemberwiseClone();
            other.testList = new ArrayList();
            for (int i = 0; i < testList.Count; i++)
            {
                Test oldTest = (Test)testList[i];
                other.testList.Add(new Test(oldTest.subject, oldTest.pass));
            }
            other.examList = new ArrayList();
            for (int i = 0; i < examList.Count; i++)
            {
                Exam oldExam = (Exam)examList[i];
                other.examList.Add(new Exam(oldExam.subject, oldExam.grade, oldExam.examDate));
            }
            return other;
        }

        interface IDateANdCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        public IEnumerable<object> GetExamsAndTests()
        {
            for (int i = 0; i < examList.Count; i++)
            {
                yield return examList[i];
            }
            for (int i = 0; i < testList.Count; i++)
            {
                yield return testList[i];
            }
        }
        public IEnumerable<object> GetExams(int gradeMin)
        {
            for (int i = 0; i < examList.Count; i++)
            {
                Exam ex = (Exam)examList[i];
                if (ex.grade > gradeMin)
                {
                    yield return examList[i];
                }
            }
        }

        public IEnumerable<object> PassedExamsAndTests()
        {
            for (int i = 0; i < examList.Count; i++)
            {
                Exam ex = (Exam)examList[i];
                if (ex.grade > 2)
                {
                    yield return examList[i];
                }
            }
            for (int i = 0; i < testList.Count; i++)
            {
                Test t = (Test)testList[i];
                if (t.pass)
                {
                    yield return testList[i];
                }
            }
        }
        public IEnumerable<object> PassedTestsWithExams()
        {

            for (int i = 0; i < testList.Count; i++)
            {
                for (int j = 0; j < examList.Count; j++)
                {
                    Test t = (Test)testList[i];
                    Exam e = (Exam)examList[j];
                    if (t.subject == e.subject && t.pass && e.grade > 2)
                    {
                        yield return testList[i];
                    }
                }
            }
        }
    }
}