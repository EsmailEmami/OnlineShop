namespace OnlineShop.Common.Exceptions
{
    public class NotAccessException : Exception
    {
        public NotAccessException()
        {
        }
        public NotAccessException(string message) : base(message)
        {
        }
    }
}
