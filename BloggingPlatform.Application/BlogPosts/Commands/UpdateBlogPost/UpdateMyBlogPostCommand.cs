using BloggingPlatform.Application.BlogPosts.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.BlogPosts.Commands.UpdateBlogPost;
public record  UpdateMyBlogPostCommand(Guid BlogPostId ,Guid UserId , string Title, string Content) : IRequest<ErrorOr<BlogPostResult>>;
