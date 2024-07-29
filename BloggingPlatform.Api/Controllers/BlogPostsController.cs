using Azure.Core;
using BloggingPlatform.Application.BlogPosts.Commands;
using BloggingPlatform.Application.BlogPosts.Commands.AddBlogPost;
using BloggingPlatform.Application.BlogPosts.Commands.DeleteBlogPost;
using BloggingPlatform.Application.BlogPosts.Commands.UpdateBlogPost;
using BloggingPlatform.Application.BlogPosts.Common;
using BloggingPlatform.Application.BlogPosts.Queries.GetFollowedUsersPosts;
using BloggingPlatform.Application.BlogPosts.Queries.GetMyBlogPosts;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Contracts.BlogPosts;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.Api.Controllers;
[Route("api/[controller]")]
public class BlogPostsController(ISender _mediator , ICurrentUserProvider _currentUser) : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddBlogPost(AddBlogPostRequest request)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();

        var command = new AddBlogPostCommand(currentUser.Id, request.Title, request.Content);

        ErrorOr<BlogPostResult> result = await _mediator.Send(command);

        return result.Match(result => Ok(result), Problem);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdateMyBlogPost(Guid id, UpdateBlogPostRequest request)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();

        var command = new UpdateMyBlogPostCommand(id,currentUser.Id, request.Title, request.Content);

        ErrorOr<BlogPostResult> result = await _mediator.Send(command);

        return result.Match(
            result => Ok(result), Problem);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteMyBlogPost(Guid id)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var command = new DeleteBlogPostCommand(id, currentUser.Id);

        ErrorOr<BlogPostResult> result = await _mediator.Send(command);

        return result.Match(
            result => Ok(result), Problem);

    }

    [HttpGet("myposts")]
    [Authorize]
    public async Task<IActionResult> GetMyBlogPosts(string? title, string? author)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var query = new GetMyBlogPostsQuery(currentUser.Id, title, author);

        ErrorOr<IEnumerable<BlogPostResult>> result = await _mediator.Send(query);

        return result.Match(
            result => Ok(result), Problem);
    }

    [HttpGet("followedPosts")]
    [Authorize]
    public async Task<IActionResult> GetFollowedUsersPosts(string? title, string? author)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var query = new GetFollowedUsersPostsQuery(currentUser.Id, title, author);

        ErrorOr<IEnumerable<BlogPostResult>> result = await _mediator.Send(query);

        return result.Match(
            result => Ok(result), Problem);
    }
}
