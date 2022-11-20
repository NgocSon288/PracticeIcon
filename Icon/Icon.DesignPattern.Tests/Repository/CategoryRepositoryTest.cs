using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icon.DesignPattern.Common;
using Icon.DesignPattern.DataAccess;
using Icon.DesignPattern.DataAccess.Models;
using Icon.DesignPattern.Repository;
using Icon.DesignPattern.Repository.Infrastructor;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Icon.DesignPattern.Tests.Repository
{
    [TestFixture]
    public class CategoryRepositoryTest : BaseRepositoryTest<Category, CategoryRepository>
    {
        [Test]
        public void GetProductsByCategoryIdTest()
        {
            var id = 1000;
            var entity = CreateEntity(id);

            _entityRepository.Add(entity);
            _unitOfWork.Commit();

            // Action
            var result = _entityRepository.GetAll("Products").FirstOrDefault(e => e.Id == id);
            var products = result.Products;

            // Compare
            Assert.AreEqual(true, products.Count > 0);
        }

        protected override Category CreateEntity(int id, params object[] args)
        {
            var rand = new Random();
            var entity = base.CreateEntity(id, args);

            entity.Products = new List<Product>()
            {
                new Product() { Name = rand.Next(10000).ToString(),CreatedAt = DateTime.Now },
                new Product() { Name = rand.Next(10000).ToString(),CreatedAt = DateTime.Now },
                new Product() { Name = rand.Next(10000).ToString(),CreatedAt = DateTime.Now },
                new Product() { Name = rand.Next(10000).ToString(),CreatedAt = DateTime.Now }
            };

            return entity;
        }
    }
}
