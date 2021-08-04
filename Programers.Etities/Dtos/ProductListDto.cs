using Programers.Entities.Concrete;
using Programers.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Entities.Dtos
{
    public class ProductListDto:DtoGetBase
    {
        public IList<Product> Products { get; set; }
        public int? CategoryId { get; set; }
    }
}
