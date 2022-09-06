using NoteApi.Exceptions;
using NoteApi.Models;

namespace NoteApi.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly HashSet<Note> _notes = new HashSet<Note> {
            new Note{ Content = "Sample Note 1"},
            new Note{ Content = "Sample Note 2"},
        };

        public void Create(Note note)
        {
            if (_notes.Any(n => n.Id == note.Id))
                throw new NoteAlreadyExistsException();

            _notes.Add(note);
        }

        public void Delete(Guid id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
                throw new NoteNotFoundException();

            _notes.Remove(note);
        }

        public IEnumerable<Note> Get()
        {
            return _notes.ToList();
        }

        public Note? Get(Guid id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public void Update(Note note)
        {
            var item = _notes.FirstOrDefault(n => n.Id == note.Id);
            if (item == null)
                throw new NoteNotFoundException();

            _notes.Remove(item);
            _notes.Add(note);
        }
    }
}
