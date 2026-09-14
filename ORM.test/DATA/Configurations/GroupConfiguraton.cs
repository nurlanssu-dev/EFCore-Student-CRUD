using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using ORM.test.Models;
using Group = ORM.test.Models.Group;

namespace ORM.test.DATA.Configurations;

internal class GroupConfiguraton : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasMany(g => g.Students)
               .WithOne(s => s.Group)
               .HasForeignKey(s => s.GroupId);
    }
}
