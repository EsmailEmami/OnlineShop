using OnlineShop.Common.Attributes;
using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Domain.Entities.System
{
    public class PeyvastFile : Entity
    {
        public PeyvastFile(string fileName, string mimeType, string originalName, PeyvastFileType type)
        {
            FileName = fileName;
            MimeType = mimeType;
            OriginalName = originalName;
            Type = type;
        }

        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string OriginalName { get; set; }
        public PeyvastFileType Type { get; set; }

        public virtual ICollection<ProductPeyvastFile> ProductPeyvastFiles { get; set; } = new List<ProductPeyvastFile>();
        public virtual ICollection<Banner.Banner> Banners { get; set; } = new List<Banner.Banner>();
    }

    public enum PeyvastFileType : short
    {
        [FilePath("wwwroot/banner")]
        Banner,

        [FilePath("wwwroot/product")]
        Product
    }
}
