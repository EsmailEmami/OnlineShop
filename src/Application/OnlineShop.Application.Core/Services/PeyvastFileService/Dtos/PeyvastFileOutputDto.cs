using OnlineShop.Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.PeyvastFileService.Dtos
{
    public class PeyvastFileOutputDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string OriginalName { get; set; }
        public PeyvastFileType Type { get; set; }

    }
}
