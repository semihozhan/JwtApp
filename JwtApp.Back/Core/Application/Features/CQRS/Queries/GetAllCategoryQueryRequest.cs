using JwtApp.Back.Core.Application.Dto;
using MediatR;


namespace JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoryQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
