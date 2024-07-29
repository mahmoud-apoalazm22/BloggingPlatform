using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.BlogPosts;

namespace BloggingPlatform.Application.Common.Interfaces;
public interface IBlogPostRepository
{
    // Add a new blog post
    Task AddAsync(BlogPost blogPost);

    // Get a blog post by its ID
    Task<BlogPost? > GetByIdAsync(Guid id);

    // Get all blog posts
    Task<IEnumerable<BlogPost>> GetAllAsync();

    // Update an existing blog post
    Task UpdateAsync(BlogPost blogPost);

    // Delete a blog post by its ID
    Task DeleteAsync(BlogPost blogPost);

    // Get blog posts by a specific user (author)
    Task<IEnumerable<BlogPost>> GetByUserIdAsync(Guid userId, string? title, string? author);
    Task<IEnumerable<BlogPost>> GetFollowedUsersPostsAsync(Guid userId, string? title, string? author);

}
