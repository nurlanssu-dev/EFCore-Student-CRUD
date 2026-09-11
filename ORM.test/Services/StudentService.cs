using Microsoft.EntityFrameworkCore;
using ORM.test.DATA;
using ORM.test.Models;

namespace ORM.test.Services;

public class StudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public StudentService()
    {
    }

    //Task 2 — Insert əməliyyatı
    public void AddStudent(string name, int age)
    {
        var student = new Student
        {
            Name = name,
            Age = age
        };
        _context.Students.Add(student);
        _context.SaveChanges();
        Console.WriteLine("Student added successfully.");
    }

    //Task 3 — Get All Students
    public void GetAllStudents()
    {
        var students = _context.Students.ToList();
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id} StudentName: {student.Name} Age: {student.Age}");
        }
    }

    //Task 4 — Search Student
    public void GetStudentByName(string name)
    {
        var student = _context.Students.FirstOrDefault(s => s.Name == name);
        if (student != null)
        {
            Console.WriteLine($"ID: {student.Id} StudentName: {student.Name} Age: {student.Age}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    //Task 5 — Update Student

    public void UpdateStudentAge(int id, int newAge)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Age = newAge;
            _context.SaveChanges();
            Console.WriteLine("Student age updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    //Task 6 — Delete Student
    public void DeleteStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    //Task 7 — Pagination

    public List<Student> GetStudentsByPage(int pageNumber)
    {
        int pageSize = 3;

        int offset = (pageNumber - 1) * pageSize;

        return _context.Students
            .FromSqlInterpolated($@"
                SELECT * FROM Students
                ORDER BY Id
                OFFSET {offset} ROWS
                FETCH NEXT {pageSize} ROWS ONLY")
            .ToList();
    }

}
