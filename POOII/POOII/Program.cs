using System;
using System.Collections.Generic;

// Classe Marks
public class Marks
{
    public int MarkId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; }
    public int Mark { get; set; }

    public bool IsPassing()
    {
        return Mark >= 60; // Exemplo: nota mínima de aprovação é 60
    }
}

// Classe Students
public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GroupId { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}

// Classe Groups
public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; }
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public List<Student> ListStudents()
    {
        return students;
    }
}

// Classe Teachers
public class Teacher
{
    public int TeacherId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}

// Classe Subjects
public class Subject
{
    public int SubjectId { get; set; }
    public string Title { get; set; }
    private List<Teacher> teachers = new List<Teacher>();

    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
    }

    public string GetFullName()
    {
        return Title;
    }
}

// Classe SubjectTeacher (Relacionamento entre Subject, Teacher e Group)
public class SubjectTeacher
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public int GroupId { get; set; }

    public void AssignTeacherToGroup(Teacher teacher, Group group)
    {
        // Implementação do método de atribuição
        Console.WriteLine($"Teacher {teacher.GetFullName()} assigned to Group {group.Name}");
    }
}

// Exemplo de uso
class Program
{
    static void Main(string[] args)
    {
        // Criando instâncias e utilizando os métodos
        var student = new Student { StudentId = 1, FirstName = "Maria", LastName = "Moura", GroupId = 101 };
        var group = new Group { GroupId = 101, Name = "Orientação a Objetos" };
        var teacher = new Teacher { TeacherId = 1, FirstName = "Clara", LastName = "Estevanovic" };
        var subject = new Subject { SubjectId = 1, Title = "Álgebra Linear" };
        var subjectTeacher = new SubjectTeacher { SubjectId = 1, TeacherId = 1, GroupId = 101 };

        group.AddStudent(student);
        subject.AddTeacher(teacher);
        subjectTeacher.AssignTeacherToGroup(teacher, group);
        
        Console.WriteLine($"Student Full Name: {student.GetFullName()}");
        Console.WriteLine($"Teacher Full Name: {teacher.GetFullName()}");
    }
}