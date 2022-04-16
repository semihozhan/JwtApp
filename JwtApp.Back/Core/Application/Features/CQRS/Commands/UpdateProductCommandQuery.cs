using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommandQuery : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
