using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Comments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BloggingPlatform.Infrastructure.Comments;
public class CommentConfigurations : IEntityTypeConfiguration<Comment>

{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Set the primary key
        builder.HasKey(c => c.Id);

        // Set the properties
        builder.Property(c => c.CommenterName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.CommenterEmail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.Content)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        // Configure the relationships
        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.BlogPost)
            .WithMany(bp => bp.Comments)
            .HasForeignKey(c => c.BlogPostId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Comments
        Comment[] comments = new[]
        {
        new Comment(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), Guid.Parse("afc8ea8d-e918-4c68-a896-8a64d9e2b3ff"), "mahmoud", "mahmoud12345@gmail.com", "This is a comment on the second post."),
        new Comment(Guid.Parse("e3f54c19-7c26-48d6-8696-1359e7e88f86"), Guid.Parse("691bb48e-4acb-4797-ad80-a048107f74c7"), "ahmed", "ahmed@gmail.com", "This is a comment on the first post.")
        };

        builder.HasData(comments);


    }
}
