﻿namespace OnlineShop.Common.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException()
        {
        }
        public DatabaseException(string message) : base("خطای پایگاه داده =>" + message)
        {
        }

        public DatabaseException(Exception ex) : base("خطای پایگاه داده =>" + ex.Message, ex.InnerException)
        {
        }
    }
}
