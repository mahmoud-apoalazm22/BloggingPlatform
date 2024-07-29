using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Users;
using ErrorOr;

namespace BloggingPlatform.Domain.Followers;
public class Follower :Entity
{
    public Guid UserId { get; private set; }
    public Guid FollowerId { get; private set; }
    public User User { get; private set; }
    public User FollowerUser { get;private set; }

    public Follower(Guid userId, Guid followerId ,Guid? id = null):base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        FollowerId = followerId;
    }


    private Follower() { }
}
