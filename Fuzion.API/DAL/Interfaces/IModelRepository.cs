using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModelsAsync();

        Task<Model> GetModelByIdAsync(int id);

        Task CreateModelAsync(Model model);

        Task UpdateModelAsync(Model model);

        Task DeleteModelAsync(Model model);
    }
}