using Programers.Entities.Concrete;
using Programers.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Data.Abstract
{
    public interface ICommentRepository:IEntityRepository<Comment>
    {
    }
}
