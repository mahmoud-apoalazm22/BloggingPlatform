using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BloggingPlatform.Application.BlogPosts.Commands.UpdateBlogPost;
public class UpdateMyBlogPostCommandValidator :AbstractValidator<UpdateMyBlogPostCommand>
{
    public UpdateMyBlogPostCommandValidator()
    {
        RuleFor(x => x.BlogPostId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}
