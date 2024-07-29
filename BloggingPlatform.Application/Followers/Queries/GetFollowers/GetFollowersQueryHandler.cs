using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Application.Followers.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Followers.Queries.GetFollowers;
public class GetFollowersQueryHandler(IFollowerRepository _followerRepository ,IUsersRepository _usersRepository) : IRequestHandler<GetFollowersQuery, ErrorOr<List<FollowerResult>>>
{
    public async Task<ErrorOr<List<FollowerResult>>> Handle(GetFollowersQuery request, CancellationToken cancellationToken)
    {
        Domain.Users.User? user = await _usersRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            return FollowerErrors.UserNotFound ;
        }

        List<Domain.Followers.Follower> followers =await _followerRepository.GetFollowersAsync(request.UserId);

        return followers.Select(f => new FollowerResult(f.Id, f.UserId, f.FollowerId)).ToList();

       
    }
}
