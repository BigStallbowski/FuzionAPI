using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Fuzion.API.Extensions;
using Fuzion.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.API.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturerController : Controller
    {
        private IUnitOfWork _uow;

        public ManufacturerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> Manufacturers()
        {
            var manufacturers = await _uow.Manufacturers.GetAllManufacturersAsync();
            return Ok(manufacturers);
        }

        [HttpGet("{id}", Name = "GetManufacturerById")]
        public async Task<ActionResult> Manufacturers(int id)
        {
            var manufacturer = await _uow.Manufacturers.GetManufacturerByIdAsync(id);

            if (manufacturer.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreateManufacturer([FromBody] Manufacturer manufacturer)
        {
            await _uow.Manufacturers.CreateManufacturerAsync(manufacturer);
            return CreatedAtRoute("GetManufacturerById", new { id = manufacturer.Id }, manufacturer);
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateManufacturer([FromBody] Manufacturer manufacturerUpdate)
        {
            if (manufacturerUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var manufacturer = await _uow.Manufacturers.GetManufacturerByIdAsync(manufacturerUpdate.Id);
            if (manufacturer.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Manufacturers.UpdateManufacturerAsync(manufacturerUpdate);
            return CreatedAtRoute("GetManufacturerById", new { id = manufacturerUpdate.Id }, manufacturerUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _uow.Manufacturers.GetManufacturerByIdAsync(id);
            if (manufacturer.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Manufacturers.DeleteManufacturerAsync(manufacturer);

            return NoContent();
        }
    }
}