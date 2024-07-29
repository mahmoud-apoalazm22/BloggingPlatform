using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Followers.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Followers.Commands.AddFollowe;
public record AddFollowerCommand(Guid UserId, Guid FollowerId) : IRequest<ErrorOr<FollowerResult>>;
