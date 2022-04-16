using JwtApp.Back.Core.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryResult: IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryResult(int id)
        {
            Id = id;
        }
    }
}
