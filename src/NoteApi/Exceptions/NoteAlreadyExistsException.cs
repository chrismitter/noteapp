using System.Runtime.Serialization;

namespace NoteApi.Exceptions
{
    [Serializable]
    public class NoteAlreadyExistsException : Exception
    {
        public NoteAlreadyExistsException() : base() { }

        public NoteAlreadyExistsException(string? message) : base(message) { }

        protected NoteAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
