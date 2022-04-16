using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandQuery>
    {
        private readonly IRepository<Product> repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandQuery request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Product {
             Stock=request.Stock,
             Price=request.Price,
             CategoryID= request.CategoryID,
             Name=request.Name
            });
            return Unit.Value;
        }
    }
}
