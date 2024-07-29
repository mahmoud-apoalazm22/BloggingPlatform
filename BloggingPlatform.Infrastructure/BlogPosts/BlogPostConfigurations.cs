using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.BlogPosts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.BlogPosts;
public class BlogPostConfigurations : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        // Set the primary key
        builder.HasKey(bp => bp.Id);

        // Set the properties
        builder.Property(bp => bp.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(bp => bp.Content)
            .IsRequired();

        builder.Property(bp => bp.CreatedAt)
            .IsRequired();

        // Configure the relationships
        builder.HasOne(bp => bp.User)
            .WithMany(u => u.BlogPosts)
            .HasForeignKey(bp => bp.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        // Seed BlogPosts
        BlogPost[] blogPosts = new[]
        {
        new BlogPost(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), "First Post", "This is the content of the first post.",Guid.Parse("691bb48e-4acb-4797-ad80-a048107f74c7")),
        new BlogPost(Guid.Parse("e3f54c19-7c26-48d6-8696-1359e7e88f86"), "Second Post", "This is the content of the second post.",Guid.Parse("afc8ea8d-e918-4c68-a896-8a64d9e2b3ff")),
        new BlogPost(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), "Third Post", "This is the content of the third post."),
        new BlogPost(Guid.Parse("e3f54c19-7c26-48d6-8696-1359e7e88f86"), "Fourth Post", "This is the content of the fourth post."),
        new BlogPost(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), "Fifth Post", "This is the content of the fifth post."),
        new BlogPost(Guid.Parse("e3f54c19-7c26-48d6-8696-1359e7e88f86"), "Sixth Post", "This is the content of the sixth post."),
        new BlogPost(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), "Seventh Post", "This is the content of the seventh post."),
        new BlogPost(Guid.Parse("e3f54c19-7c26-48d6-8696-1359e7e88f86"), "Eighth Post", "This is the content of the eighth post."),
        new BlogPost(Guid.Parse("3670dc16-c548-4142-a4e8-ccd6691dcb6c"), "Ninth Post", "This is the content of the ninth post.")
        };

        builder.HasData(blogPosts);
    }
}
