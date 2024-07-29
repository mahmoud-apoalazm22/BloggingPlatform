using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Commands.AddBlogPost;
public record AddBlogPostCommand(Guid UserId, string Title, string Content) : IRequest<ErrorOr<BlogPostResult>>;
