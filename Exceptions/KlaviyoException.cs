using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Exceptions
{
    public class KlaviyoException : Exception
    {
        public KlaviyoException(string message) : base(message) { }

        public KlaviyoException(string message, Exception inner) : base(message, inner) { }

        public KlaviyoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
