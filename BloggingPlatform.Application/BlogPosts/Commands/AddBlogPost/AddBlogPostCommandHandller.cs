using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.BlogPosts;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Commands.AddBlogPost;
public class AddBlogPostCommandHandller(IBlogPostRepository _blogPostRepository, IUnitOfWork _unitOfWork) : IRequestHandler<AddBlogPostCommand, ErrorOr<BlogPostResult>>
{
    public async Task<ErrorOr<BlogPostResult>> Handle(AddBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = new BlogPost(request.UserId, request.Title, request.Content);

        await _blogPostRepository.AddAsync(blogPost);
        await _unitOfWork.CommitChangesAsync();

        return new BlogPostResult(blogPost.Id, blogPost.UserId, blogPost.Title, blogPost.Content, blogPost.CreatedAt);
    }
}
