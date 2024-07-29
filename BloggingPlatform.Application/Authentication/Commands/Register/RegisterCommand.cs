using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using BloggingPlatform.Application.Authentication.Common;


namespace BloggingPlatform.Application.Authentication.Commands.Register;
public record RegisterCommand(string Username, string Email, string Password):IRequest<ErrorOr<AuthenticationResult>>;

