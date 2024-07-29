using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Application.Followers.Common;
public record FollowerResult(Guid Id,Guid UserId, Guid FollowerId);
