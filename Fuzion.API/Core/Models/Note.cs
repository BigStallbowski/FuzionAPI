﻿namespace Fuzion.API.Core.Models
{
    public class Note : BaseModel
    {
        public string Body { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}