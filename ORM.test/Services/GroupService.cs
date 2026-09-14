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
}