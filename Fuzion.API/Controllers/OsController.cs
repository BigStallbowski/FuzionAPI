using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Fuzion.API.Extensions;
using Fuzion.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.API.Controllers
{
    [Route("api/operatingSystems")]
    [ApiController]
    public class OsController : Controller
    {
        private IUnitOfWork _uow;

        public OsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> OperatingSystems()
        {
            var operatingSystems = await _uow.OS.GetAllOSAsync();
            return Ok(operatingSystems);
        }

        [HttpGet("{id}", Name = "GetOperatingSystemById")]
        public async Task<ActionResult> OperatingSystems(int id)
        {
            var operatingSystem = await _uow.OS.GetOSByIdAsync(id);

            if (operatingSystem.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(operatingSystem);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreateOperatingSystem([FromBody] OS os)
        {
            await _uow.OS.CreateOSAsync(os);
            return CreatedAtRoute("GetOperatingSystemById", new { id = os.Id }, os);
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateHardwareType([FromBody] OS osToUpdate)
        {
            if (osToUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var operatingSystem = await _uow.OS.GetOSByIdAsync(osToUpdate.Id);
            if (operatingSystem.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.OS.UpdateOSAsync(osToUpdate);
            return CreatedAtRoute("GetOperatingSystemById", new { id = osToUpdate.Id }, osToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOperatingSystem(int id)
        {
            var operatingSystem = await _uow.OS.GetOSByIdAsync(id);
            if (operatingSystem.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.OS.DeleteOSAsync(operatingSystem);
            return NoContent();
        }
    }
}