namespace TodoNet.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }  
    }

    public class InternalErrorException : Exception
    {
        public InternalErrorException(string message) : base(message) { }
    }

    public class BadReqeustException : Exception
    {
        public BadReqeustException(string message) : base(message) { }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}
