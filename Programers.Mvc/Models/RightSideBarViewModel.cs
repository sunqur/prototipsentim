using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Concrete;

namespace Programers.Mvc.Models
{
    public class RightSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }
    }
}
