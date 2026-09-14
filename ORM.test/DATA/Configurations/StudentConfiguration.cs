using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORM.test.Models;

namespace ORM.test.DATA.Configurations;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
       builder.HasOne(s => s.Group)
              .WithMany(g => g.Students)
              .HasForeignKey(s => s.GroupId);
    }
}
