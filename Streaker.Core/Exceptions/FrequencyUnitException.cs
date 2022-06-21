using System.Runtime.Serialization;

namespace Streaker.Core.Exceptions
{
    [Serializable]
    public class FrequencyUnitException : Exception
    {
        public FrequencyUnitException()
        {
        }

        public FrequencyUnitException(string message)
            : base(message)
        {
        }

        public FrequencyUnitException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FrequencyUnitException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
