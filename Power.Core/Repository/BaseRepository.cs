using Power.Data;
using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Repository
{
    public class BaseRepository<T, Key> : IBaseRepository<T, Key> where T : BaseEntity<Key>
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);

        }
        public void Delete(Key id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        /// <summary>
        ///     Get Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Key id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
    }
}
