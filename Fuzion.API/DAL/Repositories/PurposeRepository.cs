using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.API.DAL.Repositories
{
    public class PurposeRepository : Repository<Purpose>, IPurposeRepository
    {
        public PurposeRepository(DbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Purpose>> GetAllPurposesAsync()
        {
            var purposes = await FindAllAsync();
            return purposes.OrderBy(x => x.Name);
        }

        public async Task<Purpose> GetPurposeByIdAsync(int id)
        {
            var purpose = await FindByConditionAsync(x => x.Id.Equals(id));
            return purpose.FirstOrDefault();
        }

        public async Task CreatePurposeAsync(Purpose purpose)
        {
            Create(purpose);
            await SaveAsync();
        }

        public async Task UpdatePurposeAsync(Purpose purpose)
        {
            Update(purpose);
            await SaveAsync();
        }

        public async Task DeletePurposeAsync(Purpose purpose)
        {
            Delete(purpose);
            await SaveAsync();
        }
    }
}