using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    public abstract class BaseRepositoryTest<TEntity, EntityRepository> where EntityRepository : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        //private ApplicationDbContext _applicationDbContext;
        protected IUnitOfWork _unitOfWork;
        protected IBaseRepository<TEntity> _entityRepository;

        [SetUp]
        public virtual void Setup()
        {
            var _applicationDbContext = GetDatabaseContext();   // Use Memory database that refer to main memory
            _unitOfWork = new UnitOfWork(_applicationDbContext);
            _entityRepository = (IBaseRepository<TEntity>)Activator.CreateInstance(typeof(EntityRepository), _applicationDbContext);
        }

        [Test]
        public virtual void GetProductsTest()
        {
            var minEntity = 10;
            var entities = CreateEntities(minEntity);

            _entityRepository.AddRange(entities);
            _unitOfWork.Commit();

            // Action
            var result = _entityRepository.GetAll();

            // Compare
            Assert.AreEqual(true, result.Count() > 0);
        }

        [Test]
        public virtual void GetProductsWithinConditionEvenIDTest()
        {
            var minEntity = 10;
            var entities = CreateEntities(minEntity);

            _entityRepository.AddRange(entities);
            _unitOfWork.Commit();

            // Action
            var result = _entityRepository.GetAll(e => e.Id % 2 == 0);

            // Compare
            Assert.AreEqual(true, result.Count() > 0);
        }

        [Test]
        public virtual void GetProductsWithSpecificIdTest()
        {
            var id = 99999;
            var entity = CreateEntity(id);

            _entityRepository.Add(entity);
            _unitOfWork.Commit();

            // Action 
            var result = _entityRepository.GetById(new object[] { id });

            // Compare
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public virtual void UpdateEntityTest()
        {
            var id = 99999;
            var entity = CreateEntity(id);
            var createdAtOld = entity.CreatedAt;

            _entityRepository.Add(entity);
            _unitOfWork.Commit();

            // Action 
            var resultEntity = _entityRepository.GetById(new object[] { id });
            UpdateEntity(resultEntity);
            _entityRepository.Update(resultEntity);
            _unitOfWork.Commit();
            resultEntity = _entityRepository.GetById(new object[] { id });

            // Compare
            Assert.AreNotEqual(createdAtOld, resultEntity.CreatedAt);
        }

        [Test]
        public virtual void DeleteEntityTest()
        {
            var id = 99999;
            var entity = CreateEntity(id);
            var createdAtOld = entity.CreatedAt;

            _entityRepository.Add(entity);
            _unitOfWork.Commit();

            // Action 
            var resultEntity = _entityRepository.GetById(new object[] { id }); 
            _entityRepository.Delete(resultEntity);
            _unitOfWork.Commit();
            resultEntity = _entityRepository.GetById(new object[] { id });

            // Compare
            Assert.IsNull(resultEntity);
        }
        #region Protected Methods

        protected virtual void UpdateEntity(TEntity entity)
        {
            Thread.Sleep(2000);
            Type type = typeof(TEntity);
            PropertyInfo namePro = type.GetProperty("Name");
            PropertyInfo createdAtPro = type.GetProperty("CreatedAt");
            namePro.SetValue(entity, $"{new Random().Next(1000,10000000)} updated");
            createdAtPro.SetValue(entity, DateTime.Now);
        }

        protected virtual IEnumerable<TEntity> CreateEntities(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return CreateEntity(i + 100000);
            }
        }

        protected virtual TEntity CreateEntity(int id, params object[] args)
        {
            Type type = typeof(TEntity);
            PropertyInfo idPro = type.GetProperty("Id");
            PropertyInfo createdAtPro = type.GetProperty("CreatedAt");
            PropertyInfo namePro = type.GetProperty("Name");
            var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            idPro.SetValue(entity, id);
            namePro.SetValue(entity, $"{id + 1000}");
            createdAtPro.SetValue(entity, DateTime.Now);

            return entity;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Use the main database, but don't modify the database
        /// URL: https://dotnetthoughts.net/how-to-mock-dbcontext-for-unit-testing/
        /// </summary>
        /// <returns></returns>
        private ApplicationDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated(); 
            return databaseContext;
        }

        #endregion
    }
}
