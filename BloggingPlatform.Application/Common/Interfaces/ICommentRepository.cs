using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Comments;

namespace BloggingPlatform.Application.Common.Interfaces;
public interface ICommentRepository
{
    Task AddCommentAsync(Comment comment);
    Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(Guid blogPostId); 

}
