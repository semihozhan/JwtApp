using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandQuery : IRequest
    {
        public string? Definition { get; set; }
    }
}
