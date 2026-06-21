using System;
using System.Collections.Generic;

class Student
{
    private string name;
    private List<double> grades;

    public Student(string name)
    {
        this.name = name;
        grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }

    public string GetName()
    {
        return name;
    }

    public List<double> GetGrades()
    {
        return grades;
    }

    public double GetAverage()
    {
        double sum = 0;

        foreach (double grade in grades)
        {
            sum += grade;
        }

        return sum / grades.Count;
    }

    public double GetHighestGrade()
    {
        double highest = grades[0];

        foreach (double grade in grades)
        {
            if (grade > highest)
            {
                highest = grade;
            }
        }

        return highest;
    }
}