using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IPurposeRepository
    {
        Task<IEnumerable<Purpose>> GetAllPurposesAsync();

        Task<Purpose> GetPurposeByIdAsync(int id);

        Task CreatePurposeAsync(Purpose os);

        Task UpdatePurposeAsync(Purpose os);

        Task DeletePurposeAsync(Purpose os);
    }
}