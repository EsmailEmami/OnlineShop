namespace OnlineShop.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("دسترسی ندارید")
        {
        }
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
