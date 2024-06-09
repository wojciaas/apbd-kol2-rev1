namespace apbd_kol2cf_rev1.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }
    

        public DomainException(string? message) : base(message)
        {
        }

        public DomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}