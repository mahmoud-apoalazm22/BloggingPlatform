using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Comments;
using BloggingPlatform.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Comments;
public class CommentRepository(BloggingPlatformtDbContext _context) : ICommentRepository
{
    public async Task AddCommentAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(Guid blogPostId)
    {
        return await _context.Comments
            .Where(c => c.BlogPostId == blogPostId)
            .ToListAsync();
    }
}
