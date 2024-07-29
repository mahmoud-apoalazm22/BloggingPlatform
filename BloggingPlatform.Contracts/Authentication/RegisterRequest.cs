using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Contracts.Authentication;
public record RegisterRequest(
    string Username,
    string Email,
    string Password);
