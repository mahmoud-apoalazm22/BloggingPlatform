using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BloggingPlatform.Application.Comments.Commands.AddComment;

    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
{
    public AddCommentCommandValidator()
    {
        RuleFor(x => x.BlogPostId)
            .NotEmpty().WithMessage("BlogPostId is required.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Comment text is required.");
    }
}
