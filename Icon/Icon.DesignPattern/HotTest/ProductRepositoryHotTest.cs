using Icon.DesignPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.HotTest
{
    public interface IProductRepositoryHotTest
    {
        void Test();
    }

    public class ProductRepositoryHotTest : IProductRepositoryHotTest
    {
        private readonly IProductRepository _productRepository;

        public ProductRepositoryHotTest(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Test()
        {
            GetsTest();
        }

        private void GetsTest()
        {
            Console.WriteLine("List of products");
            
            var products = _productRepository.GetAll("Category");

            foreach (var item in products)
            {
                Console.WriteLine("{0, -5} | {1,-20} | {2,-20}", item.Id, item.Name, item.Category?.Name);
            }

            Console.WriteLine("------------------------------------------------");
        }
    }
}
