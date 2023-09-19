﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CW_Delegate_2.Program;

namespace CW_Delegate_2
{
    class Program
    {
        public delegate bool Comparer(object elem1, object elem2);

        static class BubbleSorter
        {
            static public void Sort(object[] array, Comparer comparer)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i + 1; j < array.Length; j++)
                        if (comparer(array[j], array[i]))
                        {
                            object buffer = array[i];
                            array[i] = array[j];
                            array[j] = buffer;
                        }
            }
        }

        public struct Person
        {
            public string FirstName;
            public string LastName;
            public DateTime Birthday;

            public Person(string firstName, string lastName, DateTime birthday)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Birthday = birthday;
            }

            public override string ToString()
            {
                return string.Format(
                    "Имя: {0,-10} Фамилия: {1,-10} Дата рождения: {2:d}.",
                    FirstName, LastName, Birthday);
            }
        }
        public struct Doctor 
        {
            public string FirstName;
            public string LastName;
            public string JobTitle;
            public int Sallary;
            public Doctor(string firstName, string lastName, string jobTitle, int sallary)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.JobTitle = jobTitle;
                this.Sallary = sallary;
            }

            public override string ToString()
            {
                return string.Format(
                    "Имя: {0,-10} Фамилия: {1,-10} Должность: {2, -10}, Зарплата: {3, -10}.",
                    FirstName, LastName, JobTitle, Sallary);
            }
        }

        static public bool PersonBirthdayComparer(object person1, object person2)
        {
            return ((Person)person1).Birthday < ((Person)person2).Birthday;
        }

        static public bool DoctorSallaryComparer(object doctor1, object doctor2)
        {
            return ((Doctor)doctor1).Sallary < ((Doctor)doctor2).Sallary;
        }

        static void Main(string[] args)
        {
            //Person p0 = new Person("Максим", "Орлов", new DateTime(1989, 5, 12));
            //Person p1 = new Person("Иван", "Иванов", new DateTime(1985, 7, 21));
            //Person p2 = new Person("Петр", "Петров", new DateTime(1991, 3, 1));
            //Person p3 = new Person("Федор", "Федоров", new DateTime(1971, 11, 25));
            //Person p4 = new Person("Павел", "Козлов", new DateTime(1966, 8, 6));
            //
            //object[] persons = { p0, p1, p2, p3, p4 };
            //
            //Console.WriteLine("\nНеупорядоченный список:");
            //foreach (object person in persons) Console.WriteLine(person);
            //
            //Console.WriteLine("\nОтсортированный список:");
            //BubbleSorter.Sort(persons, PersonBirthdayComparer);
            //foreach (object person in persons)
            //    Console.WriteLine(person);
            //
            //Console.WriteLine("\n");

            Doctor d0 = new Doctor("Максим", "Орлов", "Главврач", 30000);
            Doctor d1 = new Doctor("Иван", "Иванов", "Хирург", 29000);
            Doctor d2 = new Doctor("Петр", "Петров", "Ассистент", 20000);
            Doctor d3 = new Doctor("Федор", "Федоров", "Лор", 24000);
            Doctor d4 = new Doctor("Павел", "Козлов", "Ветеринар", 24000);

            Object[] doctors = { d0, d1, d2, d3, d4 };

            Console.WriteLine("\nНеупорядоченный список:");
            foreach (object doctor in doctors) Console.WriteLine(doctor);

            Console.WriteLine("\nОтсортированный список:");
            BubbleSorter.Sort(doctors, DoctorSallaryComparer);
            foreach (object doctor in doctors)
                Console.WriteLine(doctor);

            Console.WriteLine("\n");
        }
    }
}
