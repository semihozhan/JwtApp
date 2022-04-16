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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandQuery>
    {
        private readonly IRepository<Category> repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if(result != null)
            {
                await repository.RemoveAsync(result);
            }
            return Unit.Value;
        }
    }
}
