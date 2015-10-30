using System;
using System.Runtime.Serialization;

namespace SE2Game.Game
{
    [Serializable]
    internal class InvalidMapException : Exception
    {
        public InvalidMapException():base()
        {
        }

        public InvalidMapException(string message) : base(message)
        {
            
        }

        public InvalidMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidMapException(string message, DivideByZeroException zeroException) : base(message, zeroException)
        {
        }

        public InvalidMapException(string message, IndexOutOfRangeException outOfRangeException) : base(message, outOfRangeException)
        {
        }

        protected InvalidMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}