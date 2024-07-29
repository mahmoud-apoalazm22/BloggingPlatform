using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BloggingPlatform.Application.BlogPosts.Commands.AddBlogPost;
public class AddBlogPostCommandValidator : AbstractValidator<AddBlogPostCommand>
{

    public AddBlogPostCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters.");


    }

}
