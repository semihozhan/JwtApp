using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandQuery>
    {
        private readonly IRepository<AppUser> repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandQuery request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new AppUser { 
                Username= request.Username,
                Password= request.Password,
                AppRoleID= (int)AppRoleEnum.Member
            });
            return Unit.Value;
        }
    }
}
