using Microsoft.AspNetCore.Mvc;
using System;

namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase
    {
        public IActionResult Get()
        {
            throw new NotImplementedException();

        }

        public IActionResult Get(long id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Post()
        {
            throw new NotImplementedException();
        }

        public IActionResult Put()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
