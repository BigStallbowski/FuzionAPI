using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.DTOs;
using Fuzion.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.API.DAL.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(FuzionDbContext ctx) : base(ctx)
        {

        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<Device>> GetAllDevicesWithDetails()
        {
            return await FuzionContext.Devices
                .Include(h => h.DeviceType)
                .Include(h => h.Manufacturer)
                .Include(h => h.Model)
                .Include(h => h.OS)
                .Include(h => h.Purpose)
                .OrderBy(h => h.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetAssignedDevices()
        {
            return await FuzionContext.Devices
                .Where(h => h.IsAssigned == 1)
                .OrderBy(h => h.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetUnassignedDevices()
        {
            return await FuzionContext.Devices
                .Where(h => h.IsAssigned == 0)
                .OrderBy(h => h.Name)
                .ToListAsync();
        }

        public async Task<Device> GetDeviceById(int id)
        {
            var device = await FindByConditionAsync(x => x.Id.Equals(id));
            return device.FirstOrDefault();
        }

        public async Task<DeviceCounts> GetDeviceCounts()
        {
            DeviceCounts deviceCounts = new DeviceCounts
            {
                TotalAvailableDevices = await FuzionContext.Devices
                    .CountAsync(x => x.IsRetired != 1),
                TotalAvailableWorkstations = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Workstation"),
                TotalAvailableLaptops = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Laptop"),
                TotalAvailableMobileDevices = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Mobile"),
                TotalDeployedDevices = await FuzionContext.Devices
                    .CountAsync(x => x.IsAssigned == 1),
                TotalDeployedWorkstations = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Workstation" && x.IsAssigned == 1),
                TotalDeployedLaptops = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Laptop" && x.IsAssigned == 1),
                TotalDeployedMobileDevices = await FuzionContext.Devices
                    .CountAsync(x => x.DeviceType.Name == "Mobile" && x.IsAssigned == 1)
            };
            return deviceCounts;
        }

        public async Task<Device> CreateDevice(Device device)
        {
            Create(device);
            await SaveAsync();
            return device;
        }

        public async Task UpdateDevice(Device device)
        {
            Update(device);
            await SaveAsync();
        }

        public async Task DeleteDevice(Device device)
        {
            Delete(device);
            await SaveAsync();
        }

        public async Task AssignDevice(Device device)
        {
            device.IsAssigned = 1;
            Update(device);
            await SaveAsync();
        }

        public async Task UnassignDevice(Device device)
        {
            device.IsAssigned = 0;
            device.AssignedTo = null;
            Update(device);
            await SaveAsync();
        }

        public async Task RetireDevice(Device device)
        {
            device.IsAssigned = 0;
            device.AssignedTo = null;
            device.IsRetired = 1;
            Update(device);
            await SaveAsync();
        }
    }
}
