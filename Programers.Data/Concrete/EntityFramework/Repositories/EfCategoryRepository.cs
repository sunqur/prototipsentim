using Microsoft.EntityFrameworkCore;
using Programers.Data.Abstract;
using Programers.Data.Concrete.EntityFramework.Contexts;
using Programers.Entities.Concrete;
using Programers.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext contex) : base(contex)
        {

        }

        public async Task<Category> GetById(int categoryId)
        {
            return await ProgramersContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
        private ProgramersContext ProgramersContext { get
            {
                return _context as ProgramersContext;
            } }
    }
}
