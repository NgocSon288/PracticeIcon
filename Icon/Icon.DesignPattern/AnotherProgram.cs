using Icon.DesignPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern
{
    public class AnotherProgram
    {
        private readonly IProductRepository _productRepo;

        public AnotherProgram(IProductRepository productRepo)
        {
            this._productRepo = productRepo;
        }

        /// <summary>
        /// Now, We will use this Main method as the Program's Main
        /// </summary>
        public void Main()
        {
            var products = _productRepo.GetAll();

            foreach (var item in products)
            {
                Console.WriteLine("{0, -5} | {1,-20} | {2,-20}", item.Id, item.Name, item.Category?.Name);
            }
        }
    }
}
