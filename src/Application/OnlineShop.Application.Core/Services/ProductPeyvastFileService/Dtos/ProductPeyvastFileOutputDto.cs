using OnlineShop.Application.Core.Services.PeyvastFileService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos
{
    public class ProductPeyvastFileOutputDto
    {
        public Guid Id { get; set; }
        public Guid PeyvastFileId { get; set; }
        public PeyvastFileOutputDto PeyvastFile { get; set; }

        public bool IsVisiable { get; set; }
        public bool IsMain { get; set; }
        public short Priority { get; set; }
    }
}
