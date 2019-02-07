using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;

namespace Fuzion.API.DAL.Repositories
{
    public class DeviceTypeRepository : Repository<DeviceType>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<DeviceType>> GetAllDeviceTypesAsync()
        {
            var deviceTypes = await FindAllAsync();
            return deviceTypes.OrderBy(x => x.Name);
        }

        public async Task<DeviceType> GetDeviceTypeByIdAsync(int id)
        {
            var deviceType = await FindByConditionAsync(x => x.Id.Equals(id));
            return deviceType.FirstOrDefault();
        }

        public async Task CreateDeviceTypeAsync(DeviceType deviceType)
        {
            Create(deviceType);
            await SaveAsync();
        }

        public async Task UpdateDeviceTypeAsync(DeviceType deviceType)
        {
            Update(deviceType);
            await SaveAsync();
        }

        public async Task DeleteDeviceTypeAsync(DeviceType deviceType)
        {
            Delete(deviceType);
            await SaveAsync();
        }
    }
}