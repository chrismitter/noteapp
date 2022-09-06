using NoteApi.Models;

namespace NoteApi.Repositories
{
    public interface INoteRepository
    {
        void Create(Note note);
        void Delete(Guid id);
        IEnumerable<Note> Get();
        Note? Get(Guid id);
        void Update(Note note);
    }
}