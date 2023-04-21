namespace OnlineShop.Common.Dtos
{
    public interface ISPFInputDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortColumnName { get; set; }
        public SortType SortType { get; set; }
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SPFInputDto : ISPFInputDto
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string? SortColumnName { get; set; }
        public SortType SortType { get; set; } = SortType.Asc;
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }
    }


    public enum SortType : short
    {
        Asc = 10,
        Desc = 20
    }
}
