using System.Collections.Generic;

namespace OnlineShop.Common.Dtos
{
    public class SPFOutPutDto<T>
    {
        public long TotalRecord { get; set; }
        public long ShowRecord { get; set; }
        public IList<T> ResultList { get; set; } = new List<T>();
    }
}
