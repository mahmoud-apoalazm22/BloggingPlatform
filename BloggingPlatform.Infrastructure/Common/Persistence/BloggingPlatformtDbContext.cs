
using System.Reflection;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Domain.Comments;
using BloggingPlatform.Domain.Followers;
using BloggingPlatform.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Common.Persistence;

public class BloggingPlatformtDbContext(DbContextOptions<BloggingPlatformtDbContext> options) : DbContext(options) , IUnitOfWork
{

    public DbSet<User> Users { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Follower> Followers { get; set; }


    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }



}
