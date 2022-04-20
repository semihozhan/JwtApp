using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JwtApp.Back.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(RegisterUserCommandQuery registerUserCommandQuery)
        {
            await _mediator.Send(registerUserCommandQuery);
            return Created("", registerUserCommandQuery);
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> CheckUser(GetRegisterQueryResult getRegisterQueryResult)
        {
            var request = await _mediator.Send(new GetRegisterQueryResult());
            if (request.IsExists)
            {
                var token = JwtTokenGenerator.GenerateToken(request);
                return Created("", token);
            }
            return BadRequest("kullanıcı veya şifre hatalı");

        }
    }
}
