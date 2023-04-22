namespace OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos
{
    public class ProductPeyvastFileUpdateDto
    {
        public Guid Id { get; set; }
        public Guid PeyvastFileId { get; set; }
        public bool IsVisiable { get; set; }
        public bool IsMain { get; set; }
        public short Priority { get; set; }
    }
}
