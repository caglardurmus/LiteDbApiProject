using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Entities;

namespace MyProject.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult<Result> ReturnResult(string description, bool successful = true)
        {
            var result = new Result()
            {
                Successful = successful,
                Description = description
            };
            return result;
        }

        public ActionResult<Result> ReturnFailed()
        {
            return this.ReturnResult("Beklenmedik Hata!", false);
        }
    }
}