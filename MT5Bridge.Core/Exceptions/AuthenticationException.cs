using System;

namespace MT5Bridge.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }
}
