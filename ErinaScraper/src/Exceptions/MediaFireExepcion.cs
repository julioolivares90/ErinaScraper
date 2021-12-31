using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.Exceptions
{
    public class MediaFireExepcion : Exception
    {
        public MediaFireExepcion() { }

        public MediaFireExepcion(string message): base(message) { }
        
        public MediaFireExepcion(string message, Exception inner) : base(message, inner) { }

        public MediaFireExepcion(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
