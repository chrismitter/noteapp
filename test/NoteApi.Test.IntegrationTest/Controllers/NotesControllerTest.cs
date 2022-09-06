using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NoteApi.Models;
using Shouldly;
using System.Net;
using System.Net.Http.Json;

namespace NoteApi.Test.IntegrationTest.Controllers
{
    public class NotesControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public NotesControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_WhenRequestValid_ShouldCreateNote()
        {
            var client = _factory.CreateDefaultClient();
            var note = new Note { Content = "Test content" };
            await CreateNoteAsync(client, note);
            await DeleteNoteAsync(client, note.Id);
        }

        [Fact]
        public async Task Post_WhenNoContentGiven_ShouldReturnBadRequest()
        {
            var client = _factory.CreateDefaultClient();
            var note = new Note();
            var response = await client.PostAsync("/notes", JsonContent.Create(note));

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest, await response.Content.ReadAsStringAsync());

            var responseContent = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            responseContent.ShouldNotBeNull();
        }

        [Fact]
        public async Task Get_WhenNoteExists_ShouldReturnNote()
        {
            var client = _factory.CreateDefaultClient();
            var note = new Note { Content = "Test content" };
            await CreateNoteAsync(client, note);

            var response = await client.GetAsync("/notes");

            response.StatusCode.ShouldBe(HttpStatusCode.OK, await response.Content.ReadAsStringAsync());

            var responseContent = await response.Content.ReadFromJsonAsync<IEnumerable<Note>>();
            responseContent.ShouldNotBeNull();
            responseContent.Count().ShouldBe(3);
            await DeleteNoteAsync(client, note.Id);
        }

        private async Task CreateNoteAsync(HttpClient client, Note note)
        {
            var response = await client.PostAsync("/notes", JsonContent.Create(note));
            response.StatusCode.ShouldBe(HttpStatusCode.OK, await response.Content.ReadAsStringAsync());
        }

        private async Task DeleteNoteAsync(HttpClient client, Guid id)
        {
            var response = await client.DeleteAsync($"/notes/{id}");
            response.StatusCode.ShouldBe(HttpStatusCode.OK, await response.Content.ReadAsStringAsync());
        }
    }
}
