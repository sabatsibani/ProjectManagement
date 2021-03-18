using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;

namespace ProjectManagement.Api.Controllers
{
    public class ExceptionController : ControllerBase
    {
        [Route("error")]
        public ExceptionEntity Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            Response.StatusCode = 500;
            return new ExceptionEntity(exception);
        }
    }
}
