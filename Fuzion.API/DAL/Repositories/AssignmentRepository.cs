using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.API.DAL.Repositories
{
    public class AssignmentRepository : Repository<AssignmentHistory>, IAssignmentHistoryRepository
    {
        public AssignmentRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<AssignmentHistory>> GetAssignmentHistoryForHardware(int hardwareId)
        {
            return await FuzionContext.AssignmentHistory
                .Where(x => x.Device.Id == hardwareId)
                .ToListAsync();
        }

        public async Task CreateAssignmentHistory(AssignmentHistory assignmentHistory)
        {
            Create(assignmentHistory);
            await SaveAsync();
        }
    }
}