using JwtApp.Back.Core.Application.Dto;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetRegisterQueryHandler : IRequestHandler<GetRegisterQueryResult, CheckUserResponseDto>
    {
        private IRepository<AppUser> repository;
        private IRepository<AppRole> repositoryRole;
        public GetRegisterQueryHandler(IRepository<AppUser> repository, IRepository<AppRole> repositoryRole)
        {
            this.repository = repository;
            this.repositoryRole = repositoryRole;
        }

        public async Task<CheckUserResponseDto> Handle(GetRegisterQueryResult request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await repository.GetByFilter(x=>x.Username == "semih"/*request.Username && x.Password ==request.Password*/ );

            if (user == null)
            {
                dto.IsExists = false;
            }
            else
            {
                dto.Username = user.Username;
                dto.Id = user.Id;
                dto.IsExists = true;
                var role = await repositoryRole.GetByFilter(x=>x.Id == user.AppRoleID);
                dto.Role = role?.Definition;
            }

            return dto;
        }
    }
}
