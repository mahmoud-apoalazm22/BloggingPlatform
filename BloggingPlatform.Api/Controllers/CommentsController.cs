using BloggingPlatform.Application.BlogPosts.Commands.UpdateBlogPost;
using BloggingPlatform.Application.Comments.Commands.AddComment;
using BloggingPlatform.Application.Comments.Common;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Contracts.Comments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.Api.Controllers;
[Route("api/BlogPosts/")]

public class CommentsController(ISender _mediator ,ICurrentUserProvider _currentUser) : ApiController
{
    [HttpPost("{blogPostId:Guid}/comments")]
    [Authorize]
    public async Task<IActionResult> AddComment(Guid blogPostId, [FromBody] AddCommentRequest request)
    {
        Application.Common.Models.CurrentUser currentUser = _currentUser.GetCurrentUser();
        var command = new AddCommentCommand(blogPostId, currentUser.Id, request.Content);
        ErrorOr.ErrorOr<CommentResult> result = await _mediator.Send(command);

        return result.Match(
            comment => Ok(new CommentResponse(comment.BlogPostId,comment.CommenterId, comment.CommenterName, comment.CommenterEmail, comment.Connent, comment.CreatedAt)),
            errors => Problem(errors)
        );
    }
}
