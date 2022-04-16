using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandQuery : IRequest
    {
        public int Id { get; set; }
    }
}
