using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programers.Data.Abstract;
using Programers.Data.Concrete.EntityFramework.Contexts;
using Programers.Data.Concrete.EntityFramework.Repositories;

namespace Programers.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgramersContext _context;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(ProgramersContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ?? new EfProductRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
