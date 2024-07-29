
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Application.Followers.Common;
using BloggingPlatform.Domain.Followers;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Followers.Commands.AddFollowe;
public class AddFollowerCommandHandller(IFollowerRepository _followerRepository,IUsersRepository _usersRepository ,IUnitOfWork _unitOfWork)
    : IRequestHandler<AddFollowerCommand, ErrorOr<FollowerResult>>
{
    public async Task<ErrorOr<FollowerResult>> Handle(AddFollowerCommand request, CancellationToken cancellationToken)
    {
        Domain.Users.User? userToFollow =await _usersRepository.GetByIdAsync(request.FollowerId);
        if (userToFollow is null)
        {
            return FollowerErrors.FollowerNotFound;
        }
        // Validate input
        if (request.UserId == request.FollowerId)
        {
            return FollowerErrors.CannotFollowYourself;
        }

        // Check if the follower relationship already exists
        bool alreadyFollows = await _followerRepository.IsFollowerAsync(request.UserId, request.FollowerId);

        if (alreadyFollows)
        {
            return FollowerErrors.AlreadyFollowing;
        }

        // Create new follower
        var follower = new Follower(request.UserId, request.FollowerId);

        await _followerRepository.AddFollowerAsync(follower);
        await _unitOfWork.CommitChangesAsync();

        return new FollowerResult(follower.Id,follower.UserId,follower.FollowerId);

    }
}
