using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using BloggingPlatform.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Queries.GetMyBlogPosts;
public class GetMyBlogPostsQueryHandler(IBlogPostRepository _blogPostRepository)
    : IRequestHandler<GetMyBlogPostsQuery, ErrorOr<IEnumerable<BlogPostResult>>>
{
    public async Task<ErrorOr<IEnumerable<BlogPostResult>>> Handle(GetMyBlogPostsQuery request, CancellationToken cancellationToken)
    {

        IEnumerable<Domain.BlogPosts.BlogPost> blogPosts = await _blogPostRepository.GetByUserIdAsync(request.UserId,request.title,request.author);


        return blogPosts.Select(blogPost => 
        new BlogPostResult(blogPost.Id, blogPost.UserId, blogPost.Title, blogPost.Content,blogPost.CreatedAt)).ToList();
    }
}

