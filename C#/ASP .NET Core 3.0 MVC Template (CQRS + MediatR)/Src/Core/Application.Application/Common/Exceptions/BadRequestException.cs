namespace Application.Application.Common.Exceptions
{
    using System;
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}