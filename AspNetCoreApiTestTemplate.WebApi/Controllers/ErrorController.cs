using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiTestTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [HttpGet("401")]
        public IActionResult Error401()
        {
            // TODO throw new UnauthorizedException();
            throw new NotImplementedException();
        }

        [HttpGet("403")]
        public IActionResult Error403()
        {
            // TODO throw new ForbiddenException();
            throw new NotImplementedException();
        }

        [HttpGet("404")]
        public IActionResult Error404()
        {
            // TODO /throw new EntryNotFoundException("Requested record not found");
            throw new NotImplementedException();
        }

        [HttpGet("{code:int}")]
        public IActionResult Error(int code)
        {
            // TODO throw new AspNetCoreApiTestTemplateException(InternalErrorCode.UnknownError, $"Unknown error occurred. Error code is: {code}");
            throw new NotImplementedException();
        }
    }
}