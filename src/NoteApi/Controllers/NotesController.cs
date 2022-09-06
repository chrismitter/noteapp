using Microsoft.AspNetCore.Mvc;
using NoteApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NoteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "deleteNote")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            _noteService.DeleteNote(id);
            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getNotes")]
        [ProducesResponseType(typeof(IEnumerable<Note>), StatusCodes.Status200OK)]
        public IEnumerable<Note> Get()
        {
            return _noteService.GetNotes();
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public IActionResult Post(Note note)
        {
            if (string.IsNullOrWhiteSpace(note.Content))
            {
                ModelState.AddModelError(nameof(Note.Content), "Content should not be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _noteService.CreateNote(note);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Note note)
        {
            return Ok();
        }
    }
}