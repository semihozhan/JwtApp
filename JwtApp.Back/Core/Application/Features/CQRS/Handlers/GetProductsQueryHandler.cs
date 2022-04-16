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
    public class GetProductsQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data =await repository.GetByFilter(x=>x.Id==request.Id);
            return this.mapper.Map<ProductListDto>(data);
        }
    }
}
