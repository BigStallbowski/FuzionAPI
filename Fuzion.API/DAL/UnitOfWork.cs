using Fuzion.API.Core.Context;
using Fuzion.API.DAL.Interfaces;
using Fuzion.API.DAL.Repositories;

namespace Fuzion.API.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FuzionDbContext _ctx;

        public IDeviceRepository Devices { get; set; }
        public IDeviceTypeRepository DeviceTypes { get; set; }
        public IManufacturerRepository Manufacturers { get; set; }
        public IModelRepository Models { get; set; }
        public INoteRepository Notes { get; set; }
        public IOSRepository OS { get; set; }
        public IPurposeRepository Purposes { get; set; }
        public IAssignmentHistoryRepository AssignmentHistory { get; set; }

        public UnitOfWork(FuzionDbContext ctx)
        {
            _ctx = ctx;
            Devices = new DeviceRepository(_ctx);
            DeviceTypes = new DeviceTypeRepository(_ctx);
            Manufacturers = new ManufacturerRepository(_ctx);
            Models = new ModelRepository(_ctx);
            Notes = new NoteRepository(_ctx);
            OS = new OSRepository(_ctx);
            Purposes = new PurposeRepository(_ctx);
            AssignmentHistory = new AssignmentRepository(_ctx);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}