using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Domain.Comments;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Common.Interfaces;
using BloggingPlatform.Domain.Followers;

namespace BloggingPlatform.Domain.Users;

public class User :Entity
{
   
    public string Username { get; private set; }
    public string Email { get; private set; }

    private readonly string _passwordHash;
    public ICollection<BlogPost> BlogPosts { get; set; } 
    public ICollection<Comment> Comments { get; set; } 

    public ICollection<Follower> Followers { get; set; }
    public ICollection<Follower> FollowedUsers { get; set; }




    public User(string username, string email, string passwordHash ,Guid? id= null):base(id ?? Guid.NewGuid())
    {
        Username = username;
        Email = email;
        _passwordHash = passwordHash;
        BlogPosts = new HashSet<BlogPost>();
        Comments = new HashSet<Comment>();
        Followers = new HashSet<Follower>();
        FollowedUsers = new HashSet<Follower>();
    }

    public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }

    private User()
    {
    }
}
