using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Users;

namespace BloggingPlatform.Application.Authentication.Common;
public record AuthenticationResult(User User, string Token);
