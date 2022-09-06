using NoteApi.Models;

namespace NoteApi.Controllers
{
    public interface INoteService
    {
        void CreateNote(Note note);
        void DeleteNote(Guid id);
        IEnumerable<Note> GetNotes();
        void UpdateNote(Note note);
    }
}