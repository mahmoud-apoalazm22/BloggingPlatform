using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Application.Followers.Commands.AddFollowe;
using BloggingPlatform.Application.Followers.Common;
using BloggingPlatform.Application.Followers.Queries.GetFollowers;
using BloggingPlatform.Application.Followers.Queries.GetFollowing;
using BloggingPlatform.Contracts.Followers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.Api.Controllers;
[Route("api/user")]
[Authorize]
public class FollowersController(ISender _mediator, ICurrentUserProvider _currentUser) : ApiController
{
    
    [HttpPost("{userIdToFollow:Guid}/follow")]
    public async Task<IActionResult> Follow(Guid userIdToFollow)
    {
        // Retrieve the current user ID
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();

        var command = new AddFollowerCommand(currentUser.Id, userIdToFollow);

        ErrorOr.ErrorOr<Application.Followers.Common.FollowerResult> result = await _mediator.Send(command);

        return result.Match(
            result => Ok(new FollowerResponse(result.Id, result.UserId, result.FollowerId)),
           Problem);
    }

   
    [HttpDelete("{userIdToUnfollow:Guid}/unfollow")]
    public async Task<IActionResult> Unfollow(Guid userIdToUnfollow)
    {
        // Retrieve the current user ID
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();

        var command = new AddFollowerCommand(currentUser.Id, userIdToUnfollow);

        ErrorOr.ErrorOr<Application.Followers.Common.FollowerResult> result = await _mediator.Send(command);

        return result.Match(
            result => Ok(new FollowerResponse(result.Id, result.UserId, result.FollowerId)),
           Problem);
    }

    [HttpGet("Followers")]
    
    public async Task<IActionResult> GetFollowers()
    {
        // Retrieve the current user ID
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var query = new GetFollowingQuery(currentUser.Id);

        ErrorOr<List<FollowerResult>> result = await _mediator.Send(query);

        return result.Match(
            followers => Ok(followers.Select(f => new FollowerResponse(f.Id, f.UserId, f.FollowerId))),
            Problem);
    }
    [HttpGet("Following")]
    
    public async Task<IActionResult> GetFollowing()
    {
        // Retrieve the current user ID
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var query = new GetFollowersQuery(currentUser.Id);

        ErrorOr<List<FollowerResult>> result = await _mediator.Send(query);

        return result.Match(
            followers => Ok(followers.Select(f => new FollowerResponse(f.Id, f.UserId, f.FollowerId))),
            Problem);
    }
}
