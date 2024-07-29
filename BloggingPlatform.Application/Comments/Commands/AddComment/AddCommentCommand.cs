using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Comments.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Comments.Commands.AddComment;
public record  AddCommentCommand(Guid BlogPostId,Guid CommenterId, string Content)
    : IRequest<ErrorOr<CommentResult>>;

