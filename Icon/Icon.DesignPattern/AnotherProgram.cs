using Icon.DesignPattern.HotTest;
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
        private readonly IProductRepositoryHotTest _productRepositoryHotTest;
        private readonly ICategoryRepositoryHotTest  _categoryRepositoryHotTest;

        public AnotherProgram(IProductRepositoryHotTest productRepository, 
            ICategoryRepositoryHotTest categoryRepositoryHotTest)
        {
            _productRepositoryHotTest = productRepository;
            _categoryRepositoryHotTest = categoryRepositoryHotTest;
        }

        /// <summary>
        /// Now, We will use this Main method as the Program's Main
        /// </summary>
        public void Main()
        {
            // Test for ProductRepository
            _productRepositoryHotTest.Test();

            // Test for CategoryRepository
            _categoryRepositoryHotTest.Test();
        }
    }
}
