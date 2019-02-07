using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Fuzion.API.Extensions;
using Fuzion.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.API.Controllers
{
    [Route("api/deviceTypes")]
    [ApiController]
    public class DeviceTypesController : Controller
    {
        private IUnitOfWork _uow;

        public DeviceTypesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> DeviceTypes()
        {
            var deviceTypes = await _uow.DeviceTypes.GetAllDeviceTypesAsync();
            return Ok(deviceTypes);
        }

        [HttpGet("{id}", Name = "GetDeviceTypeById")]
        public async Task<ActionResult> DeviceTypes(int id)
        {
            var deviceType = await _uow.DeviceTypes.GetDeviceTypeByIdAsync(id);

            if (deviceType.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(deviceType);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreateDeviceType([FromBody] DeviceType deviceType)
        {
            await _uow.DeviceTypes.CreateDeviceTypeAsync(deviceType);
            return CreatedAtRoute("GetHardwareTypeById", new { id = deviceType.Id }, deviceType);
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateDeviceType([FromBody] DeviceType deviceTypeUpdate)
        {
            if (deviceTypeUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var deviceType = await _uow.DeviceTypes.GetDeviceTypeByIdAsync(deviceTypeUpdate.Id);
            if (deviceType.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.DeviceTypes.UpdateDeviceTypeAsync(deviceTypeUpdate);
            return CreatedAtRoute("GetHardwareTypeById", new { id = deviceTypeUpdate.Id }, deviceTypeUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeviceType(int id)
        {
            var deviceType = await _uow.DeviceTypes.GetDeviceTypeByIdAsync(id);
            if (deviceType.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.DeviceTypes.DeleteDeviceTypeAsync(deviceType);
            return NoContent();
        }
    }
}