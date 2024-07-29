using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.BlogPosts.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Commands.DeleteBlogPost;
public record DeleteBlogPostCommand(Guid BlogPostId , Guid UserId) : IRequest<ErrorOr<BlogPostResult>>;
