using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IDeviceTypeRepository
    {
        Task<IEnumerable<DeviceType>> GetAllDeviceTypesAsync();

        Task<DeviceType> GetDeviceTypeByIdAsync(int id);

        Task CreateDeviceTypeAsync(DeviceType deviceType);

        Task UpdateDeviceTypeAsync(DeviceType deviceType);

        Task DeleteDeviceTypeAsync(DeviceType deviceType);
    }
}