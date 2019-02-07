using System.Collections.Generic;

namespace Fuzion.API.Core.Models
{
    public class DeviceType : BaseModel
    {
        public string Name { get; set; }

        public List<Device> Device { get; set; }
    }
}