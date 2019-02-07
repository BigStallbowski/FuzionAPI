using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.DTOs;
using Fuzion.API.DAL.Interfaces;
using Fuzion.API.Extensions;
using Fuzion.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.API.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : Controller
    {
        private IUnitOfWork _uow;

        public DeviceController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> Hardware()
        {
            var hardware = await _uow.Devices.GetAllDevicesWithDetails();
            return Ok(hardware);
        }

        [HttpGet("assignedDevices")]
        public async Task<ActionResult> AssignedHardware()
        {
            var assignedHardware = await _uow.Devices.GetAssignedDevices();
            return Ok(assignedHardware);
        }

        [HttpGet("unassignedDevices")]
        public async Task<ActionResult> UnassignedHardware()
        {
            var unassignedHardware = await _uow.Devices.GetUnassignedDevices();
            return Ok(unassignedHardware);
        }

        [HttpGet("{id}", Name = "GetDeviceById")]
        public async Task<ActionResult> Device(int id)
        {
            var device = await _uow.Devices.GetDeviceById(id);

            if (device.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpGet("deviceCounts")]
        public async Task<ActionResult> HardwareCounts()
        {
            var hardwareCounts = await _uow.Devices.GetDeviceCounts();
            return Ok(hardwareCounts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDevice([FromBody] Device device)
        {
            var newHardware = await _uow.Devices.CreateDevice(device);
            return Ok(new ApiResponse<Device> { Status = true, Model = newHardware });
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateDevice([FromBody] Device deviceToUpdate)
        {
            if (deviceToUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var hardware = await _uow.Devices.GetDeviceById(deviceToUpdate.Id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Devices.UpdateDevice(deviceToUpdate);
            return CreatedAtRoute("GetHardwareById", new { id = hardware.Id }, hardware);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> AssignDevice([FromBody] DeviceAssignmentWizard deviceToAssign)
        {
            var device = await _uow.Devices.GetDeviceById(deviceToAssign.Id);
            if (device.IsEmptyObject())
            {
                return NotFound();
            }

            device.AssignedTo = deviceToAssign.AssignedTo;
            device.PurposeId = deviceToAssign.PurposeId;

            await _uow.Devices.AssignDevice(device);

            if (!string.IsNullOrEmpty(deviceToAssign.NoteBody))
            {
                var deviceNote = new Note
                {
                    DeviceId = deviceToAssign.Id,
                    Body = deviceToAssign.NoteBody
                };
                await _uow.Notes.CreateNote(deviceNote);
            }

            var assignmentHistory = new AssignmentHistory
            {
                DeviceId = device.Id,
                Body = $"Assigned To: {device.AssignedTo}"
            };
            await _uow.AssignmentHistory.CreateAssignmentHistory(assignmentHistory);

            return CreatedAtRoute("GetHardwareById", new { id = device.Id, device });
        }

        [HttpPut("{id}/unassign")]
        public async Task<ActionResult> UnassignDevice([FromBody] Device deviceToUnassign)
        {
            if (deviceToUnassign.IsObjectNull())
            {
                return BadRequest("Object is null");
            }
            if (string.IsNullOrEmpty(deviceToUnassign.AssignedTo))
            {
                return BadRequest("Assigned To Field Required");
            }

            var hardware = await _uow.Devices.GetDeviceById(deviceToUnassign.Id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Devices.UnassignDevice(deviceToUnassign);

            var assignmentHistory = new AssignmentHistory
            {
                DeviceId = deviceToUnassign.Id,
                Body = "Unassigned"
            };
            await _uow.AssignmentHistory.CreateAssignmentHistory(assignmentHistory);

            return CreatedAtRoute("GetDeviceById", new { id = deviceToUnassign.Id, deviceToUnassign });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            var device = await _uow.Devices.GetDeviceById(id);
            if (device.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Devices.DeleteDevice(device);
            return NoContent();
        }
    }
}
