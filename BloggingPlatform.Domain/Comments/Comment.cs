using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Users;

namespace BloggingPlatform.Domain.Comments;
public class Comment : Entity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid BlogPostId { get; private set; }
    public BlogPost BlogPost { get; private set; }
    public string CommenterName { get; private set; }
    public string CommenterEmail { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Comment(Guid userId, Guid blogPostId, string commenterName, string commenterEmail, string content, Guid? id = null)
        :base(id??Guid.NewGuid())
    {
        UserId = userId;
        BlogPostId = blogPostId;
        CommenterName = commenterName;
        CommenterEmail = commenterEmail;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    private Comment() { }
}
