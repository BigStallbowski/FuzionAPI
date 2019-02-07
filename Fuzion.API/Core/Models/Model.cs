using System.Collections.Generic;

namespace Fuzion.API.Core.Models
{
    public class Model : BaseModel
    {
        public string Name { get; set; }

        public List<Device> Device { get; set; }
    }
}