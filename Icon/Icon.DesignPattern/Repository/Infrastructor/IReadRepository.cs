using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.Repository.Infrastructor
{
    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(params object[] keyValues);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(string navigationPropertyPath);
    }
}
