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
    public class UpdateCategoryQeueryRequest : IRequestHandler<UpdateCategoryCommandQuery>
    {
        private readonly IRepository<Category> repository;

        public UpdateCategoryQeueryRequest(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            var requests = await repository.GetByIdAsync(request.Id);
            if (requests != null)
            {
                requests.Definition = request.Definition;
                await repository.UpdateAsync(requests);
            }
            return Unit.Value;
        }
    }
}
