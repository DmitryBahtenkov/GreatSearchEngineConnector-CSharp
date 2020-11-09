using System;

namespace GSEConnectorSharp.Exceptions
{
    public class GSEException : Exception
    {
        public GSEException(string message) : base(message)
        { }
    }
}