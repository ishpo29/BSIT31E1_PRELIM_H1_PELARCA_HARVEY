using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public List<double> Grades = new List<double>();

    public double GetAverage()
    {
        double sum = 0;
        foreach (double g in Grades)
        {
            sum += g;
        }
        return Grades.Count > 0 ? sum / Grades.Count : 0;
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grades");
            Console.WriteLine("3. View Students");
            Console.WriteLine("4. Class Statistics");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddStudent(); break;
                case 2: AddGrades(); break;
                case 3: ViewStudents(); break;
                case 4: ShowStats(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        students.Add(new Student { Name = name });

        Console.WriteLine("Student added successfully.");
    }

    static void AddGrades()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        var student = students.Find(s => s.Name == name);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter grade: ");
        double grade = double.Parse(Console.ReadLine());

        student.Grades.Add(grade);

        Console.WriteLine("Grade added.");
    }

    static void ViewStudents()
    {
        foreach (var s in students)
        {
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Average: {s.GetAverage():F2}");
            Console.WriteLine("-------------------");
        }
    }

    static void ShowStats()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double total = 0;
        double highest = 0;
        string topStudent = "";

        foreach (var s in students)
        {
            double avg = s.GetAverage();
            total += avg;

            if (avg > highest)
            {
                highest = avg;
                topStudent = s.Name;
            }
        }

        double classAverage = total / students.Count;

        Console.WriteLine($"Class Average: {classAverage:F2}");
        Console.WriteLine($"Top Student: {topStudent}");
        Console.WriteLine($"Highest Average: {highest:F2}");
    }
}