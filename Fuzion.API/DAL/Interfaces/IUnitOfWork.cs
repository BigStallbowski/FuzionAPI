using System;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository Devices { get; set; }
        IDeviceTypeRepository DeviceTypes { get; set; }
        IManufacturerRepository Manufacturers { get; set; }
        IModelRepository Models { get; set; }
        INoteRepository Notes { get; set; }
        IOSRepository OS { get; set; }
        IPurposeRepository Purposes { get; set; }
        IAssignmentHistoryRepository AssignmentHistory { get; set; }
    }
}