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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandQuery>
    {
        private readonly IRepository<Product> repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandQuery request, CancellationToken cancellationToken)
        {
            var data =await repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                await repository.RemoveAsync(data);
            }
            return Unit.Value;
        }
    }
}
