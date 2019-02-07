using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.API.Core.Context;
using Fuzion.API.Core.Models;
using Fuzion.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.API.DAL.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<Note>> GetNotesForHardware(int hardwareId)
        {
            return await FuzionContext.Notes
                .Where(x => x.Device.Id == hardwareId)
                .ToListAsync();
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            var note = await FindByConditionAsync(x => x.Id.Equals(id));
            return note.FirstOrDefault();
        }

        public async Task CreateNote(Note note)
        {
            Create(note);
            await SaveAsync();
        }

        public async Task UpdateNote(Note note)
        {
            Update(note);
            await SaveAsync();
        }

        public async Task DeleteNote(Note note)
        {
            Delete(note);
            await SaveAsync();
        }
    }
}