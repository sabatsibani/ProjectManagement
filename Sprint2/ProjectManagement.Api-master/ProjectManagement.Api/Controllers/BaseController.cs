using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase
    {
        [HttpGet]
        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult Get(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Post(T data)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Add")]
        public IActionResult Put(T data)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
