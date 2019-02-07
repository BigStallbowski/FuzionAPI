using System;

namespace Fuzion.API.Core.Models
{
    public class BaseModel : IEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}