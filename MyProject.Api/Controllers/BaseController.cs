using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Entities;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ActionResult<Result> ReturnResult(string description, object obj = null, bool successful = true)
        {
            var result = new Result()
            {
                Successful = successful,
                Description = description,
                Object = obj
            };

            return result;
        }

        public ActionResult<Result> ReturnFailed(string message)
        {
            return this.ReturnResult(message, false);
        }
    }
}