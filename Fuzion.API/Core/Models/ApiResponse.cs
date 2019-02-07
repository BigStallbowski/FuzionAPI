using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fuzion.API.Core.Models
{
    public class ApiResponse<T> where T : class
    {
        public bool Status { get; set; }
        public T Model { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}