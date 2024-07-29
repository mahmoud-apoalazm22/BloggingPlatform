using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Users;
using System.Xml.Linq;
using BloggingPlatform.Domain.Comments;

namespace BloggingPlatform.Domain.BlogPosts;
public class BlogPost : Entity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Comment> Comments { get; set; } 

    public BlogPost(Guid userId, string title, string content, Guid? id = null): base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow; // Automatically set the creation date
        Comments = new List<Comment>();
    }

    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
    }

    private BlogPost() { }
}
