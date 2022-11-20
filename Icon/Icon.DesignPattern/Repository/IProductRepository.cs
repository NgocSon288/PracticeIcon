using Icon.DesignPattern.DataAccess.Models;
using Icon.DesignPattern.Repository.Infrastructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
