using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IOSRepository
    {
        Task<IEnumerable<OS>> GetAllOSAsync();

        Task<OS> GetOSByIdAsync(int id);

        Task CreateOSAsync(OS os);

        Task UpdateOSAsync(OS os);

        Task DeleteOSAsync(OS os);
    }
}