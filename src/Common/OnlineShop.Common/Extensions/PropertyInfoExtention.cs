using System.Reflection;

namespace OnlineShop.Common.Extensions
{
    public static class PropertyInfoExtention
    {
        public static bool IsBooleanType(this PropertyInfo o)
        {
            switch (o.PropertyType.Name)
            {
                case "Boolean":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// آیا نوع عددی است؟
        /// </summary>
        public static bool IsNumericType(this PropertyInfo o)
        {
            switch (o.PropertyType.Name)
            {
                case "Byte":
                case "SByte":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                case "Int16":
                case "Int32":
                case "Int64":
                case "Decimal":
                case "Double":
                case "Single":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// آیا نوع اعشاری است؟
        /// </summary>
        public static bool IsDecimalType(this PropertyInfo o)
        {
            switch (o.PropertyType.Name)
            {
                case "Decimal":
                case "Double":
                case "Single":
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsStringType(this PropertyInfo o)
        {
            switch (o.PropertyType.Name)
            {
                case "String":
                    return true;
                default:
                    return false;
            }
        }
    }
}
