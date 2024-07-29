using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Contracts.Followers;
public record FollowerResponse(Guid Id,Guid UserId, Guid FollowerId);
