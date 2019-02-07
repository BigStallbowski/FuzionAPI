using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;

namespace Fuzion.API.DAL.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Model>> GetAllModelsAsync()
        {
            var models = await FindAllAsync();
            return models.OrderBy(x => x.Name);
        }

        public async Task<Model> GetModelByIdAsync(int id)
        {
            var model = await FindByConditionAsync(x => x.Id.Equals(id));
            return model.FirstOrDefault();
        }

        public async Task CreateModelAsync(Model model)
        {
            Create(model);
            await SaveAsync();
        }

        public async Task UpdateModelAsync(Model model)
        {
            Update(model);
            await SaveAsync();
        }

        public async Task DeleteModelAsync(Model model)
        {
            Delete(model);
            await SaveAsync();
        }
    }
}