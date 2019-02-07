using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.DTOs;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllDevicesWithDetails();

        Task<IEnumerable<Device>> GetAssignedDevices();

        Task<IEnumerable<Device>> GetUnassignedDevices();

        Task<Device> GetDeviceById(int id);

        Task<DeviceCounts> GetDeviceCounts();

        Task<Device> CreateDevice(Device device);

        Task UpdateDevice(Device device);

        Task DeleteDevice(Device device);

        Task AssignDevice(Device device);

        Task UnassignDevice(Device device);

        Task RetireDevice(Device device);
    }
}