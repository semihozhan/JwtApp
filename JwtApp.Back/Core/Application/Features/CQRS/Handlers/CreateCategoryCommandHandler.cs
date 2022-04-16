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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandQuery>
    {
        private IRepository<Category> repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category {
                Definition=request.Definition
            });
            return Unit.Value;
        }
    }
}
