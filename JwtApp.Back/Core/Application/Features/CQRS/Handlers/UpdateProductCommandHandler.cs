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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandQuery>
    {
        private IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandQuery request, CancellationToken cancellationToken)
        {

            var result = await repository.GetByIdAsync(request.Id);
            if (result != null)
            {
                result.Name = request.Name;
                result.Price = request.Price;
                result.Stock = request.Stock;
                await repository.UpdateAsync(result);
            }

            return Unit.Value;
        }
    }
}
