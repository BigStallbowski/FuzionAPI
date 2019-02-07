using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();

        Task<Manufacturer> GetManufacturerByIdAsync(int id);

        Task CreateManufacturerAsync(Manufacturer manufacturer);

        Task UpdateManufacturerAsync(Manufacturer manufacturer);

        Task DeleteManufacturerAsync(Manufacturer manufacturer);
    }
}