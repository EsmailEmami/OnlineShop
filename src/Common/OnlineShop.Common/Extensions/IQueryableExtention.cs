using System.Linq.Expressions;
using System.Linq;
using System.Text.RegularExpressions;
using OnlineShop.Common.Dtos;
using System.Linq.Dynamic.Core;

namespace OnlineShop.Common.Extensions
{
    public static class IQueryableExtentions
    {
        public class PropertyNameType
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public Type Type { get; set; }
        }

        /// <summary>
        /// It's do sorting, paging and filtering
        /// </summary>
        public static IQueryable<T> SPF<T, SPFInputDto>(this IQueryable<T> query, SPFInputDto model, out long totalRecord)
            where SPFInputDto : class , ISPFInputDto
        {
            return query.Sort(model.SortColumnName, model.SortType).Filter(model.SearchTerm)
                .Paging(model.PageSize, model.PageNumber, out totalRecord);
        }

        /// <summary>
        /// It's do sorting, paging and filtering based on the properties passed to the method
        /// </summary>
        public static IQueryable<T> SPF<T, SPFInputDto>(this IQueryable<T> query, SPFInputDto model, List<PropertyNameType> propertyNamesTypes, out long totalRecord)
            where SPFInputDto : class, ISPFInputDto
        {
            return query.Sort(model.SortColumnName, model.SortType)
                .Filter(model.SearchTerm, propertyNamesTypes)
                .Paging(model.PageSize, model.PageNumber, out totalRecord);
        }

        /// <summary>
        /// It's do sorting, paging and filtering based on the properties passed to the method
        /// </summary>
        public static IQueryable<T> SPF<T, SPFInputDto>(this IQueryable<T> query, SPFInputDto model, Expression<Func<T, bool>> filterExpression, out long totalRecord)
            where SPFInputDto : class, ISPFInputDto
        {
            return query.Sort(model.SortColumnName, model.SortType)
                .Filter(filterExpression)
                .Paging(model.PageSize, model.PageNumber, out totalRecord);
        }

        /// <summary>
        /// It's do sorting
        /// </summary>
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string sortColumnName, Dtos.SortType sortType)
        {
            var props = typeof(T).GetProperties().Select(x => x.Name);
            // اعمال سورت روی اطلاعات
            if (sortColumnName.HasValue())
            {
                var sortTypeStr = sortType == Dtos.SortType.Asc ? "ASC" : "DESC";
                query = query?.OrderBy($"{sortColumnName} {sortTypeStr}");
            }
            else if (props.Any(c => c.ToLower().Equals("id")))
            {
                query = query?.OrderBy($"Id DESC");
            }

            return query;
        }

        /// <summary>
        /// It's do filtering based on the properties passed to the method
        /// </summary>
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string search,
            List<PropertyNameType> propertyNamesTypes)
        {
            // اعمال فیلتر
            if (search.HasValue())
            {
                var searchTerm = search.Trim().ToLower();
                //searchTerm = CleanInput(searchTerm);
                var searchQ = string.Empty;

                var propertiesNameTypeList = propertyNamesTypes;

                for (var i = 0; i < propertiesNameTypeList.Count; i++)
                {
                    // بررسی نوع داده
                    if (propertiesNameTypeList[i].Type == typeof(string))
                    {
                        searchQ += "(";

                        var splitedField = propertiesNameTypeList[i].Name.Split('.');

                        for (int x = 0; x < splitedField.Length; x++)
                        {
                            var res = string.Join(".", splitedField.Take(x + 1));
                            searchQ += $"{res} != null && ";
                        }

                        searchQ += $"{propertiesNameTypeList[i].Name}.ToLower().Contains" + $"(\"{searchTerm}\")) || ";
                    }
                    else if (propertiesNameTypeList[i].Type == typeof(DateTime?) ||
                             propertiesNameTypeList[i].Type == typeof(DateTime))
                    {
                        // ignore search for date time
                    }
                    else if (propertiesNameTypeList[i].Type.IsEnum)
                    {
                        // ignore search for enum
                    }
                    else
                    {
                        // آیا نوع اعشاری هست؟
                        if (propertiesNameTypeList[i].Type == typeof(double))
                        {
                            // اگر سرچ قابل تبدیل به اعشاری بود، آن را تبدیل کن
                            if (double.TryParse(searchTerm, out double parsedSearchTerm))
                            {
                                searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                        else if (propertiesNameTypeList[i].Type == typeof(decimal))
                        {
                            // اگر سرچ قابل تبدیل به اعشاری بود، آن را تبدیل کن
                            if (decimal.TryParse(searchTerm, out decimal parsedSearchTerm))
                            {
                                searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                        else if (propertiesNameTypeList[i].Type == typeof(float))
                        {
                            // اگر سرچ قابل تبدیل به اعشاری بود، آن را تبدیل کن
                            if (float.TryParse(searchTerm, out float parsedSearchTerm))
                            {
                                if (parsedSearchTerm % 1 == 0)
                                {
                                    searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm} || ";
                                }
                                else
                                {
                                    searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm}f || ";
                                }
                            }
                        }
                        else if (propertiesNameTypeList[i].Type == typeof(bool))
                        {
                            //ToDo: we should decide for boolean.
                        }
                        else if (propertiesNameTypeList[i].Type == typeof(int))
                        {
                            // اگر سرچ قابل تبدیل به int بود، آن را تبدیل کن
                            if (int.TryParse(searchTerm, out var parsedSearchTerm))
                            {
                                searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                        else
                        {
                            // اگر سرچ قابل تبدیل به عددی بود، آن را تبدیل کن
                            if (long.TryParse(searchTerm, out var parsedSearchTerm))
                            {
                                searchQ += $"{propertiesNameTypeList[i].Name} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                    }
                }

                // حذف 4 کاراکتر اضافی انتهای سرچ تولید شده
                searchQ = searchQ.Remove(searchQ.Length - 4);

                // اعمال سرچ
                query = query.Where(searchQ);
            }

            return query;
        }

        /// <summary>
        /// It's do filtering based on the properties passed to the method
        /// </summary>
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string search)
        {
            if (search.HasValue())
            {
                var searchTerm = search.Trim().ToLower();
                searchTerm = CleanInput(searchTerm);
                var searchQ = string.Empty;

                var objectProperties = typeof(T).GetProperties();
                var objPropertiesLength = objectProperties.Length;

                var objPropertiesName = new string[objPropertiesLength];

                // بیرون کشیدن نام پراپرتی ها
                for (var i = 0; i < objPropertiesLength; i++)
                {
                    objPropertiesName[i] = objectProperties[i].Name;
                }

                for (var i = 0; i < objPropertiesLength; i++)
                {
                    // بررسی نوع داده
                    if (objectProperties[i].IsStringType())
                    {
                        searchQ += $"({objPropertiesName[i]} != null && " +
                                   $"{objPropertiesName[i]}.ToLower().Contains" + $"(\"{searchTerm}\")) || ";
                    }
                    else
                    {
                        // اگر نوع عددی نبود برو به ابتدای حلقه
                        if (!objectProperties[i].IsNumericType()) continue;

                        // آیا نوع اعشاری هست؟
                        if (objectProperties[i].IsDecimalType())
                        {
                            // اگر سرچ قابل تبدیل به اعشاری بود، آن را تبدیل کن
                            if (decimal.TryParse(searchTerm, out decimal parsedSearchTerm))
                            {
                                searchQ += $"{objPropertiesName[i]} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                        else
                        {
                            // اگر سرچ قابل تبدیل به عددی بود، آن را تبدیل کن
                            if (long.TryParse(searchTerm, out var parsedSearchTerm))
                            {
                                searchQ += $"{objPropertiesName[i]} == " + $"{parsedSearchTerm} || ";
                            }
                        }
                    }
                }

                // حذف 4 کاراکتر اضافی انتهای سرچ تولید شده
                searchQ = searchQ.Remove(searchQ.Length - 4);

                // اعمال سرچ
                query = query.Where(searchQ);
            }

            return query;
        }

        /// <summary>
        /// It's do filtering based on the expression
        /// </summary>
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return query.Where(expression);
        }

        /// <summary>
        /// It's do sorting, paging and filtering based on the properties passed to the method
        /// </summary>
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int pageSize, int pageNumber,
            out long totalRecord)
        {
            totalRecord = query?.LongCount() ?? 0;

            // صفحه بندی
            query = query?.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return query;
        }

        /// <summary>
        /// Strip Invalid Characters from a String
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        private static string CleanInput(string strIn)
        {
            try
            {
                string regexSearch =
                    new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex($"[{Regex.Escape(regexSearch)}]");
                strIn = r.Replace(strIn, "");

                return strIn;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
