using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.API.Core.Models;

namespace Fuzion.API.DAL.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesForHardware(int hardwareId);

        Task<Note> GetNoteByIdAsync(int id);

        Task CreateNote(Note note);

        Task UpdateNote(Note note);

        Task DeleteNote(Note note);
    }
}