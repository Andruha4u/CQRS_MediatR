using System;
using System.Runtime.Serialization;

namespace BS.Queries.Object.Exceptions
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        private readonly string v;
        private readonly int id;

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string v, int id)
        {
            this.v = v;
            this.id = id;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}