using Microsoft.EntityFrameworkCore;
using ORM.test.DATA;
using ORM.test.Models;

namespace ORM.test.Services;

public class GroupService
{
    private readonly AppDbContext _context;

    public GroupService(AppDbContext context)
    {
        _context = context;
    }


    public void AddGroup(string name)
    {
        var group = new Group
        {
            Name = name
        };

        _context.Groups.Add(group);
        _context.SaveChanges();
    }


    public List<Group> GetAllGroups()
    {
        return _context.Groups.ToList();
    }


    public Group? GetGroupById(int id)
    {
        return _context.Groups
            .FirstOrDefault(g => g.Id == id);
    }

    public void UpdateGroup(int id, string newName)
    {
        var group = _context.Groups
            .FirstOrDefault(g => g.Id == id);
        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return;
        }
        group.Name = newName;
        _context.SaveChanges();
    }
    public void DeleteGroup(int id)
    {
        var group = _context.Groups
            .FirstOrDefault(g => g.Id == id);
        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return;
        }
        _context.Groups.Remove(group);
        _context.SaveChanges();
    }

    //GetStudentsByGroup

    public void GetStudentsByGroup(int groupId)
    {
        var group = _context.Groups
            .Include(g => g.Students)
            .FirstOrDefault(g => g.Id == groupId);
        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return;
        }
        Console.WriteLine($"Students in Group {group.Name}:");
        foreach (var student in group.Students)
        {
            Console.WriteLine($"ID: {student.Id} Name: {student.Name} Age: {student.Age}");
        }
    }

}