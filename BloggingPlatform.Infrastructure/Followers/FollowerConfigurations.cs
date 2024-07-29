using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Followers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Followers;
public class FollowerConfigurations : IEntityTypeConfiguration<Follower>
{
    public void Configure(EntityTypeBuilder<Follower> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.UserId);

        builder.Property(f => f.FollowerId);

        builder
           .HasKey(f => new { f.UserId, f.FollowerId });


        builder
           .HasOne(f => f.User)
           .WithMany(u => u.Followers)
           .HasForeignKey(f => f.UserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(f => f.FollowerUser)
            .WithMany(u => u.FollowedUsers)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
