using System.Collections.Generic;

namespace Fuzion.API.Core.Models
{
    public class Device : BaseModel
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public byte IsAssigned { get; set; }
        public byte IsRetired { get; set; }
        public string AssignedTo { get; set; }

        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int? OSId { get; set; }
        public OS OS { get; set; }

        public int? PurposeId { get; set; }
        public Purpose Purpose { get; set; }

        public List<Note> Notes { get; set; }
        public List<AssignmentHistory> AssignmentHistory { get; set; }
    }
}