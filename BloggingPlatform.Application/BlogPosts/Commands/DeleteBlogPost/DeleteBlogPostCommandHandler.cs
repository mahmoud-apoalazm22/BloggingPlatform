using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using BloggingPlatform.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Commands.DeleteBlogPost;
public class DeleteBlogPostCommandHandler(IBlogPostRepository _blogPostRepository ,IUnitOfWork  _unitOfWork) : IRequestHandler<DeleteBlogPostCommand, ErrorOr<BlogPostResult>>
{
    public async Task<ErrorOr<BlogPostResult>> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
    {
        Domain.BlogPosts.BlogPost? blogPost = await _blogPostRepository.GetByIdAsync(request.BlogPostId);

        if (blogPost is null)
        {
            return BlogPostErrors.BlogPostNotFound;
        }
        if (blogPost.UserId != request.UserId)
        {
            return BlogPostErrors.NotAllowed;
        }

        await _blogPostRepository.DeleteAsync(blogPost);

        await _unitOfWork.CommitChangesAsync();

        return new BlogPostResult(blogPost.Id, blogPost.UserId, blogPost.Title, blogPost.Content,blogPost.CreatedAt); 
    }
}
