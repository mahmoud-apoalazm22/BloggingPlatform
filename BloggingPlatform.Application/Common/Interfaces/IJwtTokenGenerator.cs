using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Domain.Users;

namespace BloggingPlatform.Application.Common.Interfaces;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
