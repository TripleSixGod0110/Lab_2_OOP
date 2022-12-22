using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class Person
    {
        protected string name;
        protected string surname;
        protected DateTime birthDate;
        public Person(string studentname, string studentsurname, System.DateTime studentBirthDate)
        {
            this.name = studentname;
            this.surname = studentsurname;
            this.birthDate = studentBirthDate;
        }
        public Person()
        {
            this.name = "Artem";
            this.surname = "Gladchenko";
            this.birthDate = new DateTime(2003, 10, 01); 
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        public int Value { get; set; }
        public override string ToString()
        {
            return "Имя: " + name + " Фамилия: " + surname + " Дата рождения: " + birthDate.ToString();
        }
        public virtual string ToShortString()
        {
            return "Имя: " + name + "\n" + "Фамилия: " + Surname + "\n";
        }

        public override bool Equals(object obj)
        {
            Person p = (Person)obj;
            return name == p.name && surname == p.surname && birthDate == p.birthDate;

        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + surname.GetHashCode() + birthDate.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            return other;
        }
        interface IDateANdCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

    }
}
