using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandQuery : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
