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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
