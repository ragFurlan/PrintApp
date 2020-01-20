using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTeste.Util
{
    public class FullQueueException : System.Exception
    {

        public FullQueueException() : base() { }
        public FullQueueException(string message) : base(message) { }
        public FullQueueException(string message, Exception inner) : base(message, inner) { }

        protected FullQueueException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
