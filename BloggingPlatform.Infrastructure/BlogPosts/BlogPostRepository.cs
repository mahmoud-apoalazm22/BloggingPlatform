using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.BlogPosts;
public class BlogPostRepository(BloggingPlatformtDbContext _context) : IBlogPostRepository
{
    public async Task AddAsync(BlogPost blogPost)
    {
        await _context.BlogPosts.AddAsync(blogPost);
    }

    public Task DeleteAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Remove(blogPost);

        return Task.CompletedTask;

    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts.AsNoTracking()
                             .ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _context.BlogPosts.AsNoTracking()
            .FirstOrDefaultAsync(bp => bp.Id == id);
    }

    public async Task<IEnumerable<BlogPost>> GetByUserIdAsync(Guid userId,string? title ,string? author)
    {
        IQueryable<BlogPost> query = _context.BlogPosts.AsNoTracking()
                    .Where(bp => bp.UserId == userId)
                    .Include(bp => bp.User)
                    .AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(bp => bp.Title.Contains(title));
        }

        if (!string.IsNullOrWhiteSpace(author))
        {
            query = query.Where(bp => bp.User.Username.Contains(author));
        }

        return await query.OrderByDescending(bp => bp.CreatedAt).ToListAsync();
        
    }

    public async Task<IEnumerable<BlogPost>> GetFollowedUsersPostsAsync(Guid userId, string? title, string? author)
    {
            List<Guid> followedUserIds = await _context.Followers
               .Where(f => f.UserId == userId)
               .Select(f => f.FollowerId)
               .ToListAsync();


        IQueryable<BlogPost> query = _context.BlogPosts.AsNoTracking()
                    .Where(bp => followedUserIds.Contains(bp.UserId))
                    .Include(bp => bp.User)
                    .AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(bp => bp.Title.Contains(title));
        }

        if (!string.IsNullOrWhiteSpace(author))
        {
            query = query.Where(bp => bp.User.Username.Contains(author));
        }

        return await query.OrderByDescending(bp => bp.CreatedAt).ToListAsync();
    }

    public Task UpdateAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Update(blogPost);
        return Task.CompletedTask;
    }
}
