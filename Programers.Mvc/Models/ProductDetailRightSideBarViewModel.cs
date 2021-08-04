using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;

namespace Programers.Mvc.Models
{
    public class ProductDetailRightSideBarViewModel
    {
        public string Header { get; set; }
        public ProductListDto ProductListDto { get; set; }
        public User User { get; set; }
    }
}
