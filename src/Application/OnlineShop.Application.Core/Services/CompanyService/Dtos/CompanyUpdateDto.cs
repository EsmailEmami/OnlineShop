using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.CompanyService.Dtos
{
    public class CompanyUpdateDto
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
    }
}
