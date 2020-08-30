using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalPersonsHandbook.Service.Services;

namespace NaturalPersonsHandbook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        HelperService helperService;

        public HelperController(HelperService helperService)
        {
            this.helperService = helperService;
        }


        [HttpGet]
        [Route("GetGenders")]
        public async Task<IActionResult> GetGenders()
        {
            var data = await helperService.GetGendersAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCyties")]
        public async Task<IActionResult> GetCyties()
        {
            var data = await helperService.GetCytiesAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetRelationshipTypes")]
        public async Task<IActionResult> GetRelationshipTypes()
        {
            var data = await helperService.GetRelationshipTypesAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetNaturalPersonRelationships")]
        public async Task<IActionResult> GetNaturalPersonRelationships()
        {
            var data = await helperService.GetNaturalPersonRelationshipsAsync();
            return Ok(data);
        }
    }
}
