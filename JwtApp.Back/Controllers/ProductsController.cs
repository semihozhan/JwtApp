using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> ListById(int id)
        {
            var result = await mediator.Send(new GetProductQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await mediator.Send(new DeleteProductCommandQuery(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandQuery requst)
        {
            await mediator.Send(requst);
            return Created("",requst);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandQuery updateProductCommandQuery)
        {
            await mediator.Send(updateProductCommandQuery);
            return Created("",updateProductCommandQuery);
        }


    }
}
