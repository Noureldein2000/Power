using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Repository
{
    public interface IBaseRepository<T, Key> where T : BaseEntity<Key>
    {
        T GetById(Key id);
        T Add(T entity);
        void Delete(Key id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();

    }
}
