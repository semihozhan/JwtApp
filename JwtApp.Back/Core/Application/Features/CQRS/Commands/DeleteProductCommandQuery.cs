using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandQuery : IRequest
    {
        public int Id { get; set; }
        public DeleteProductCommandQuery(int Id)
        {
            Id = Id;
        }
    }
}
