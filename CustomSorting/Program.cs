using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name;
    public int Age;
    public int Marks;

    public Student(string name, int age, int marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        int markCompare = y.Marks.CompareTo(x.Marks);
        if (markCompare != 0)
            return markCompare;
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            var parts = Console.ReadLine().Split();
            students.Add(new Student(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
        }

        students.Sort(new StudentComparer());

        foreach (var s in students)
            Console.WriteLine(s.Name + " " + s.Age + " " + s.Marks);
    }
}