using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Followers;
using BloggingPlatform.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Infrastructure.Followers;
public class FollowerRepository(BloggingPlatformtDbContext _dbContext) : IFollowerRepository
{
    public async Task AddFollowerAsync(Follower follower)
    {

       await _dbContext.Followers.AddAsync(follower);
       

    }

    public async Task<List<Follower>> GetFollowersAsync(Guid userId)
    {
        return await _dbContext.Followers.AsNoTracking()
             .Where(x => x.UserId == userId)
             .ToListAsync();         
    }

    public async Task<List<Follower>> GetFollowingAsync(Guid userId)
    {
        return await _dbContext.Followers.AsNoTracking()
                     .Where(x => x.FollowerId == userId)
                     .ToListAsync();
    }

    public async Task<bool> IsFollowerAsync(Guid userId, Guid followerId)
    {
        return await  _dbContext.Followers
            .AnyAsync(x => x.UserId == userId && x.FollowerId == followerId);
    }

    public Task RemoveFollowerAsync(Follower follower)
    {

        _dbContext.Followers.Remove(follower);

        return Task.CompletedTask;
    }


}
