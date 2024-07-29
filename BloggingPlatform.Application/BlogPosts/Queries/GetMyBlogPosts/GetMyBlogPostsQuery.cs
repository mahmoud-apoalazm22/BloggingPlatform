using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Queries.GetMyBlogPosts;
public record GetMyBlogPostsQuery(Guid UserId , string? title, string? author) : IRequest<ErrorOr<IEnumerable<BlogPostResult>>>;
