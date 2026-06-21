using System;
using System.Collections.Generic;

class Program
{
    private List<Student> students = new List<Student>();

    static void Main()
    {
        Program app = new Program();
        app.Run();
    }

    public void Run()
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
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Student student = new Student(name);

        Console.Write("Enter grade 1: ");
        student.AddGrade(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 2: ");
        student.AddGrade(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 3: ");
        student.AddGrade(double.Parse(Console.ReadLine()));

        students.Add(student);

        Console.WriteLine("Student added successfully!");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            List<double> grades = student.GetGrades();

            Console.WriteLine("\nName: " + student.GetName());
            Console.WriteLine("Grades: " +
                grades[0] + ", " +
                grades[1] + ", " +
                grades[2]);

            Console.WriteLine("Average: " +
                student.GetAverage().ToString("F2"));
        }
    }

    public void ComputeClassAverage()
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

        Console.WriteLine("Overall Average Grade: " +
            (total / students.Count).ToString("F2"));
    }

    public void FindHighestGrade()
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
            if (student.GetHighestGrade() > highestGrade)
            {
                highestGrade = student.GetHighestGrade();
                topStudent = student.GetName();
            }
        }

        Console.WriteLine("Top Student: " + topStudent);
        Console.WriteLine("Highest Grade: " + highestGrade);
    }
}