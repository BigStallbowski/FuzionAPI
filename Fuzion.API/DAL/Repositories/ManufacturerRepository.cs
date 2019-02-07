using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;

namespace Fuzion.API.DAL.Repositories
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            var manufacturers = await FindAllAsync();
            return manufacturers.OrderBy(x => x.Name);
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int id)
        {
            var manufacturer = await FindByConditionAsync(x => x.Id.Equals(id));
            return manufacturer.FirstOrDefault();
        }

        public async Task CreateManufacturerAsync(Manufacturer manufacturer)
        {
            Create(manufacturer);
            await SaveAsync();
        }

        public async Task UpdateManufacturerAsync(Manufacturer manufacturer)
        {
            Update(manufacturer);
            await SaveAsync();
        }

        public async Task DeleteManufacturerAsync(Manufacturer manufacturer)
        {
            Delete(manufacturer);
            await SaveAsync();
        }
    }
}
