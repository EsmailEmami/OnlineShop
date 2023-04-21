using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.Extensions
{
    public static class ConvertExtension
    {
        public static TResult Parse<TResult>(this object? value, TResult defaultValue = default!)
        {
            if (value == null)
                return defaultValue;

            try
            {
                return (TResult)TypeDescriptor.GetConverter(typeof(TResult)).ConvertFrom(value)! ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
