using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface IAssignmentHistoryRepository
    {
        Task<IEnumerable<AssignmentHistory>> GetAssignmentHistoryForHardware(int hardwareId);

        Task CreateAssignmentHistory(AssignmentHistory assignmentHistory);
    }
}