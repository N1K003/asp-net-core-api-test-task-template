using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApiTestTemplate.Data.Queries;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure;
using AspNetCoreApiTestTemplate.WebApi.Models.Mappers;
using AspNetCoreApiTestTemplate.WebApi.Models.Request;
using AspNetCoreApiTestTemplate.WebApi.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AspNetCoreApiTestTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    [Produces(ApplicationConstants.DefaultMediaType)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetUsers([FromQuery] ByIdsRequest request)
        {
            var query = new GetUsersQuery(request.Ids);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return Ok(result.Select(x => x.MapToResponse()));
        }

        [HttpGet("{id:int}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetUser([FromRoute] ByIdRequest request)
        {
            var query = new GetUserQuery(request.Id);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);
            return Ok(result.MapToResponse());
        }
    }
}