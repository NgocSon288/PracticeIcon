using Icon.DesignPattern.DataAccess;
using Icon.DesignPattern.DataAccess.Models;
using Icon.DesignPattern.Repository.Infrastructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
