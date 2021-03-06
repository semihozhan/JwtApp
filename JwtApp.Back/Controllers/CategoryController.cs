using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Back.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Category()
        {
            var result = await mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryByFilter(int id)
        {
            var result = await mediator.Send(new GetCategoryQueryResult(id));
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandQuery createCategoryCommandQuery)
        {
            await mediator.Send(createCategoryCommandQuery);
            return Created("", createCategoryCommandQuery);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandQuery updateCategoryCommandQuery)
        {
            await mediator.Send(updateCategoryCommandQuery);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommandQuery deleteCategoryCommandQuery)
        {
            await mediator.Send(deleteCategoryCommandQuery);
            return NoContent();
        }
    }
}
