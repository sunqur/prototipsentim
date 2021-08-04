using Programers.Entities.Concrete;
using Programers.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Entities.Dtos
{
    public class ProductDto:DtoGetBase
    {
        public Product Product { get; set; }
    }
}
