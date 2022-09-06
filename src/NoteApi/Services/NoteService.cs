using NoteApi.Models;
using NoteApi.Repositories;

namespace NoteApi.Controllers
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepo;
        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository noteRepo, ILogger<NoteService> logger)
        {
            _noteRepo = noteRepo;
            _logger = logger;
        }

        public void CreateNote(Note note)
        {
            _logger.LogInformation("Create note {id}", note.Id);
            _noteRepo.Create(note);
        }

        public void DeleteNote(Guid id)
        {
            _logger.LogInformation("Delete note {id}", id);
            _noteRepo.Delete(id);
        }

        public IEnumerable<Note> GetNotes()
        {
            return _noteRepo.Get();
        }

        public void UpdateNote(Note note)
        {
            _logger.LogInformation("Update note {id}", note.Id);
            _noteRepo.Update(note);
        }
    }
}