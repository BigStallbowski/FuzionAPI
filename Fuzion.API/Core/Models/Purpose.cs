using System.Collections.Generic;

namespace Fuzion.API.Core.Models
{
    public class Purpose : BaseModel
    {
        public string Name { get; set; }

        public List<Device> Device { get; set; }
    }
}