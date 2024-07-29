
using BloggingPlatform.Application.Authentication.Commands.Register;
using BloggingPlatform.Application.Authentication.Common;
using BloggingPlatform.Application.Authentication.Queries.Login;
using BloggingPlatform.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.Api.Controllers;
[Route("api/[controller]")]
[AllowAnonymous]
public class UsersController(ISender _mediator) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password);

       ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(authResult => Ok(MapToAuthResponse(authResult)), Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == AuthenticationErrors.InvalidCredentials)
        {
            return Problem(
                detail: authResult.FirstError.Description,
                statusCode: StatusCodes.Status401Unauthorized);
        }

        return authResult.Match(
            authResult => Ok(MapToAuthResponse(authResult)),
            Problem);
    }
    private static AuthenticationResponse MapToAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.User.Email,
            authResult.Token);
    }

}
