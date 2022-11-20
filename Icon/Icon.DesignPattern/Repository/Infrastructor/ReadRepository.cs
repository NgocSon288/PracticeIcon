using Icon.DesignPattern.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.Repository.Infrastructor
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        protected DbContext _context;

        public ReadRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(string navigationPropertyPath)
        {
            return _context.Set<T>().Include(navigationPropertyPath).ToList();
        }
        public T GetById(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
    }
}
