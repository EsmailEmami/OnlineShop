using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Banner
{
    public class Banner : Entity
    {
        public Guid PeyvastFileId { get; set; }
        public virtual PeyvastFile PeyvastFile { get; set; }

        public BannerType BannerType { get; set; }
        public bool IsVisiable { get; set; }
    }

    public enum BannerType : short
    {
        [Display(Name = "اسلایدر صفحه اصلی")]
        MainSlider
    }
}
