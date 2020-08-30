using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NaturalPersonsHandbook.Service.Res.Resources;

namespace NaturalPersonsHandbook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        IStringLocalizer localizer;
        public ErrorController(IStringLocalizerFactory factory)
        {
            var type = typeof(GeneralResource);
            localizer = factory.Create(type);
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            this.HttpContext.Response.StatusCode = 500;
            return new JsonResult(new { error = localizer["GeneralError"].Value });
        }


    }
}
