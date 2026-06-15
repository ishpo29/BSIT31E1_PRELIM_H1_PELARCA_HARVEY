using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public List<double> Grades = new List<double>();

    public double GetAverage()
    {
        double sum = 0;

        foreach (double grade in Grades)
        {
            sum += grade;
        }

        return sum / Grades.Count;
    }

    public double GetHighestGrade()
    {
        double highest = Grades[0];

        foreach (double grade in Grades)
        {
            if (grade > highest)
            {
                highest = grade;
            }
        }

        return highest;
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    ComputeClassAverage();
                    break;

                case 4:
                    FindHighestGrade();
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Student student = new Student();

        Console.Write("Enter student name: ");
        student.Name = Console.ReadLine();

        Console.Write("Enter grade 1: ");
        student.Grades.Add(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 2: ");
        student.Grades.Add(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 3: ");
        student.Grades.Add(double.Parse(Console.ReadLine()));

        students.Add(student);

        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n===== STUDENT LIST =====");

        foreach (Student student in students)
        {
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Grades: " +
                student.Grades[0] + ", " +
                student.Grades[1] + ", " +
                student.Grades[2]);

            Console.WriteLine("Average: " +
                student.GetAverage().ToString("F2"));

            Console.WriteLine();
        }
    }

    static void ComputeClassAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double total = 0;

        foreach (Student student in students)
        {
            total += student.GetAverage();
        }

        double classAverage = total / students.Count;

        Console.WriteLine("\n===== CLASS AVERAGE =====");
        Console.WriteLine("Overall Average Grade: " +
            classAverage.ToString("F2"));
    }

    static void FindHighestGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double highestGrade = 0;
        string topStudent = "";

        foreach (Student student in students)
        {
            double currentHighest = student.GetHighestGrade();

            if (currentHighest > highestGrade)
            {
                highestGrade = currentHighest;
                topStudent = student.Name;
            }
        }

        Console.WriteLine("\n===== HIGHEST GRADE =====");
        Console.WriteLine("Top Student: " + topStudent);
        Console.WriteLine("Highest Grade: " + highestGrade);
    }
}