﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        

        Task<int> SaveAsync();
    }
}
