/*
Create a class for People that contains a name along with a corresponding get/set (using automatic properties). 
Create 2 derived classes which inherit from People and each class should have their own method. 
Demonstrate creating objects from each class and setting the name along with calling the method you created for that class.

*/

using System;

namespace HW6Inheritance
{
    class People
    {
        private string name;
        public string Name 
        { 
            get
            { 
                return name;
            }
            set
            { 
                name = value;
            } 
        }
    }

    class Student : People
    {
        public void PrintStudent()
        {
            Console.WriteLine("Student Name: " + Name);
        }
    }

    class Teacher : People
    {
        public void PrintTeacher()
        {
            Console.WriteLine("Teacher Name: " + Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "John Doe";
            student.PrintStudent();

            Teacher teacher = new Teacher();
            teacher.Name = "Jane Doe";
            teacher.PrintTeacher();
        }
    }
}