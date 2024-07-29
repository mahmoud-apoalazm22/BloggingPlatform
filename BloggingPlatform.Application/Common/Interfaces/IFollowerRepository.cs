using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Followers;

namespace BloggingPlatform.Application.Common.Interfaces;
public interface IFollowerRepository
{
    Task AddFollowerAsync(Follower follower);
    Task RemoveFollowerAsync(Follower follower);
    Task<bool> IsFollowerAsync(Guid userId, Guid followerId);
    Task<List<Follower>> GetFollowersAsync(Guid userId);
    Task<List<Follower>> GetFollowingAsync(Guid userId);


}
