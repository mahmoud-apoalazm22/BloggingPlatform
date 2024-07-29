using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Users;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username);

        builder.Property(u => u.Email);

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");


    }
}
