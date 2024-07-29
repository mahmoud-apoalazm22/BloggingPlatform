using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Followers.Common;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Followers.Commands.UnFollow;
public record UnFollowCommand (Guid UserId, Guid UserIdToUnfollow)
    :IRequest<ErrorOr<FollowerResult>>;
