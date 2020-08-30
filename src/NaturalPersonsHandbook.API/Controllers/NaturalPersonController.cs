using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalPersonsHandbook.Service.Models;
using NaturalPersonsHandbook.Service.Services;

namespace NaturalPersonsHandbook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalPersonController : ControllerBase
    {
        NaturalPersonService naturalPersonService;

        public NaturalPersonController(NaturalPersonService naturalPersonService)
        {
            this.naturalPersonService = naturalPersonService;
        }

        [HttpGet]
        [Route("GetNaturalPerson")]
        public async Task<IActionResult> GetNaturalPerson(int id)
        {
            var data = await this.naturalPersonService.GetNaturalPersonAsync(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("AddNaturalPerson")]
        public async Task<IActionResult> AddNaturalPerson([FromForm] NaturalPersonModel model)
        {
            await this.naturalPersonService.AddNaturalPersonAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateNaturalPerson")]
        public async Task<IActionResult> UpdateNaturalPerson(NaturalPersonModel model)
        {
            await this.naturalPersonService.UpdateNaturalPersonAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateNaturalPersonsImage")]
        public async Task<IActionResult> UpdateNaturalPersonsImage([FromForm]IFormFile image, [FromForm]int naturalPersonId)
        {
            await this.naturalPersonService.UpdateNaturalPersonsImageAsync(image, naturalPersonId);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateNaturalPersonRelationships")]
        public async Task<IActionResult> UpdateNaturalPersonRelationships(List<NaturalPersonRelationshipModel> model)
        {
            await this.naturalPersonService.UpdateNaturalPersonRelationshipsAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteNaturalPerson")]
        public async Task<IActionResult> DeleteNaturalPerson(int id)
        {
            await this.naturalPersonService.DeleteNaturalPersonAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllNaturalPersons")]
        public async Task<IActionResult> GetAllNaturalPersons()
        {
            var data = await this.naturalPersonService.GetAllNaturalPersonsAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("FastSearch")]
        public async Task<IActionResult> FastSearch(string content, int? pageNumber , int pageSize)
        {
            var data = await this.naturalPersonService.FastSearch(content, pageNumber, pageSize);
            return Ok(data);
        }

        [HttpPost]
        [Route("FullSearch")]
        public async Task<IActionResult> FullSearch(FullSearchModel model)
        {
            var data = await this.naturalPersonService.FullSearchAsync(model);
            return Ok(data);
        }

        [HttpGet]
        [Route("Report")]
        public async Task<IActionResult> Report()
        {
            var data = await this.naturalPersonService.ReportAsync();
            return Ok(data);
        }


    }
}
