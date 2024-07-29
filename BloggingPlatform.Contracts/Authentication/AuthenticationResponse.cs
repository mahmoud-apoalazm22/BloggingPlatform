using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string UserName,
    string Email,
    string Token);
