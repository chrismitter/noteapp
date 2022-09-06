namespace NoteApi.Models
{
    public record Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
    }
}
