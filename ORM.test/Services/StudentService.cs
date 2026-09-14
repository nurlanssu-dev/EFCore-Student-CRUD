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


    // Add Student
    public void AddStudent(string name, int age, int groupId)
    {
        var group = _context.Groups
            .FirstOrDefault(g => g.Id == groupId);

        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return;
        }

        var student = new Student
        {
            Name = name,
            Age = age,
            GroupId = groupId
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        Console.WriteLine("Student added successfully.");
    }


    // Get All Students
    public void GetAllStudents()
    {
        var students = _context.Students
            .Include(s => s.Group)
            .ToList();

        foreach (var student in students)
        {
            Console.WriteLine(
                $"ID: {student.Id} Name: {student.Name} Age: {student.Age} Group: {student.Group.Name}"
            );
        }
    }


    // Search Student
    public void GetStudentByName(string name)
    {
        var student = _context.Students
            .Include(s => s.Group)
            .FirstOrDefault(s => s.Name == name);

        if (student != null)
        {
            Console.WriteLine(
                $"ID: {student.Id} Name: {student.Name} Age: {student.Age} Group: {student.Group.Name}"
            );
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }


    // Delete Student
    public void DeleteStudent(int id)
    {
        var student = _context.Students
            .FirstOrDefault(s => s.Id == id);

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

    // update student group
    public void UpdateStudent(int id, string name, int age, int groupId)
    {
        var student = _context.Students
            .FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            var group = _context.Groups
                .FirstOrDefault(g => g.Id == groupId);

            if (group == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            student.Name = name;
            student.Age = age;
            student.GroupId = groupId;

            _context.SaveChanges();

            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // ChangeStudentGroup


    public void ChangeStudentGroup(int studentId, int newGroupId)
    {
        var student = _context.Students
            .FirstOrDefault(s => s.Id == studentId);
        if (student != null)
        {
            var group = _context.Groups
                .FirstOrDefault(g => g.Id == newGroupId);
            if (group == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }
            student.GroupId = newGroupId;
            _context.SaveChanges();
            Console.WriteLine("Student group changed successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // Pagination
    public List<Student> GetStudentsByPage(int pageNumber)
    {
        int pageSize = 3;

        return _context.Students
            .Include(s => s.Group)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}
