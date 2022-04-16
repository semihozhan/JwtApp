using AutoMapper;
using JwtApp.Back.Core.Application.Dto;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryResult, CategoryListDto>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryResult request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByFilter(x=>x.Id==request.Id);
            return mapper.Map<CategoryListDto>(result);
        }
    }
}
