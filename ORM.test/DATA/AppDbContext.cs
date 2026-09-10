using Microsoft.EntityFrameworkCore;
using ORM.test.Models;

namespace ORM.test.DATA;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=StudentOrmDb;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}