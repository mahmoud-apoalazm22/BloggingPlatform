using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using BloggingPlatform.Application.Comments.Common;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Comments;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Comments.Commands.AddComment;
public class AddCommentCommandHandler(ICommentRepository _commentRepository,IUsersRepository _usersRepository, IBlogPostRepository _blogPostRepository ,IUnitOfWork _unitOfWork)
    : IRequestHandler<AddCommentCommand, ErrorOr<CommentResult>>
{
    public async Task<ErrorOr<CommentResult>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        Domain.Users.User? user = await _usersRepository.GetByIdAsync(request.CommenterId);
        if (user is null)
        {
            return Error.NotFound("User", "User not found");
        }
        // Check if the associated blog post exists
        Domain.BlogPosts.BlogPost? blogPost = await _blogPostRepository.GetByIdAsync(request.BlogPostId);

        if (blogPost is null)
        {
            return BlogPostErrors.BlogPostNotFound;
        }
        var comment = new Comment(
                request.CommenterId,
                request.BlogPostId,
                user.Username,
                user.Email,
                request.Content);

        await _commentRepository.AddCommentAsync(comment);
        await _unitOfWork.CommitChangesAsync();

        return new CommentResult(comment.BlogPostId,request.CommenterId, comment.CommenterName,comment.CommenterEmail, comment.Content, comment.CreatedAt);
    }
}
