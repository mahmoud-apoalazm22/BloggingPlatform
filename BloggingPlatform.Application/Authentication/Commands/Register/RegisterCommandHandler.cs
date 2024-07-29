using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingPlatform.Application.Authentication.Common;
using BloggingPlatform.Application.Common.Interfaces;
using BloggingPlatform.Domain.Common.Interfaces;
using BloggingPlatform.Domain.Users;
using ErrorOr;
using MediatR;

namespace BloggingPlatform.Application.Authentication.Commands.Register;
public class RegisterCommandHandler(IJwtTokenGenerator _jwtTokenGenerator,
                                    IPasswordHasher _passwordHasher,
                                    IUsersRepository _usersRepository,
                                    IUnitOfWork _unitOfWork) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.ExistsByEmailAsync(request.Email))
        {
            return Error.Conflict(description: "User already exists");
        }

        ErrorOr<string> hashPasswordResult = _passwordHasher.HashPassword(request.Password);
        if (hashPasswordResult.IsError)
        {
            return hashPasswordResult.Errors;
        }

        var user = new User(
            request.Username,
            request.Email,
            hashPasswordResult.Value);

        await _usersRepository.AddUserAsync(user);
        await _unitOfWork.CommitChangesAsync();
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }
}
