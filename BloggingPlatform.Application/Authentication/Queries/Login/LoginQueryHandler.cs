using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Authentication.Common;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Authentication.Queries.Login;
public class LoginQueryHandler(IJwtTokenGenerator _jwtTokenGenerator , IUsersRepository _userRepository , IPasswordHasher _passwordHasher) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        Domain.Users.User? user = await _userRepository.GetByEmailAsync(request.Email);

        return user is null || !user.IsCorrectPasswordHash(request.Password, _passwordHasher)
            ? AuthenticationErrors.InvalidCredentials : new AuthenticationResult(user, _jwtTokenGenerator.GenerateToken(user));


    }
}
