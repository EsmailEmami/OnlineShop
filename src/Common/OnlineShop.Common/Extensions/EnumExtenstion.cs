using OnlineShop.Common.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OnlineShop.Common.Extensions
{
    public static class EnumExtenstion
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        public static string GetEnumDescription<T>(T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false
            );

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetDescription<T>(this object enumerationValue) where T : struct
        {
            // throw an exception if enumerationValue is not an Enum
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of Enum type", "T");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    //Pull out the description value
                    return attributes[0].Description;
                }
            }

            //In case we have no description attribute, we'll just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static T ParseEnum<T>(this string stringValue, T defaultValue)
        {
            // throw an exception if T is not an Enum
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be of Enum type", "T");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] fields = type.GetFields();

            foreach (var field in fields)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == stringValue)
                {
                    return (T)Enum.Parse(typeof(T), field.Name);
                }
            }

            //In case we couldn't find a matching description attribute, we'll just return the defaultValue that we provided
            return defaultValue;
        }

        public static string GetDisplayName(this Enum? enumValue)
        {
            try
            {
                return enumValue?.GetType()?.GetMember(enumValue.ToString())?.FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>()?.GetName()!;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static List<EnumSelectListItem> GetEnumSelectList<T>()
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(item => new EnumSelectListItem
            {
                Key = Convert.ToInt32(Convert.ChangeType(item, (item as Enum).GetTypeCode())),
                Name = GetDisplayName(item as Enum),
            })).ToList();
        }
    }
}
