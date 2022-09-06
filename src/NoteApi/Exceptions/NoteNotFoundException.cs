using System.Runtime.Serialization;

namespace NoteApi.Exceptions
{
    [Serializable]
    public class NoteNotFoundException : Exception
    {
        public NoteNotFoundException() : base() { }

        public NoteNotFoundException(string? message) : base(message) { }

        protected NoteNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
