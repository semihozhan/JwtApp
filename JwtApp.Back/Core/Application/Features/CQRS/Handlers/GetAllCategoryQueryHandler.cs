using AutoMapper;
using JwtApp.Back.Core.Application.Dto;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;


namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetAllCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();
            return this.mapper.Map<List<CategoryListDto>>(result);
        }
    }
}
