using OnlineShop.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.Attributes
{
    public class FilePathAttribute : Attribute
    {
        public string Path { get; private set; }

        public FilePathAttribute(string path)
        {
            Path = path.Trim();
        }
    }
}
