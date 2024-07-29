using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Application.Followers.Common;
using BloggingPlatform.Domain.Followers;
using BloggingPlatform.Domain.Users;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Followers.Commands.UnFollow;
public class UnfollowCommandHandler(IFollowerRepository _followerRepository,IUnitOfWork unitOfWork)
    : IRequestHandler<UnFollowCommand, ErrorOr<FollowerResult>>
{
    public async Task<ErrorOr<FollowerResult>> Handle(UnFollowCommand request, CancellationToken cancellationToken)
    {
        // Check if the user is actually following the other user
        bool isFollowing = await _followerRepository.IsFollowerAsync(request.UserId, request.UserIdToUnfollow);

        if (!isFollowing)
        {
            return FollowerErrors.NotFollowing;
        }
        // Remove the follower relationshipvar follower = new Follower
        var follower = new Follower(request.UserId, request.UserIdToUnfollow);

        await _followerRepository.RemoveFollowerAsync(follower);

        await unitOfWork.CommitChangesAsync();
        
        return new FollowerResult(follower.Id, follower.UserId, follower.FollowerId);
    }


    
}
