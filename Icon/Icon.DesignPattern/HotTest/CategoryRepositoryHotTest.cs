using Icon.DesignPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.HotTest
{
    public interface ICategoryRepositoryHotTest
    {
        void Test();
    }

    public class CategoryRepositoryHotTest : ICategoryRepositoryHotTest
    {
        private readonly ICategoryRepository _categoryRepository; 

        public CategoryRepositoryHotTest(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        public void Test()
        {
            GetsTest();
        }

        private void GetsTest()
        {
            Console.WriteLine("List of Categories");

            var categories = _categoryRepository.GetAll("Products");

            foreach (var category in categories)
            {
                Console.WriteLine($"*** {category.Name} ***");
                foreach (var product in category.Products)
                {
                    Console.WriteLine("\t{0, -5} | {1,-20}", product.Id, product.Name);
                }
                Console.WriteLine();
            }

            Console.WriteLine("------------------------------------------------");
        }
    }
}
