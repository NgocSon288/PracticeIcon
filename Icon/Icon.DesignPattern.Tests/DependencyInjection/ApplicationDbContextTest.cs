using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icon.DesignPattern.Common;
using Icon.DesignPattern.DataAccess;
using Icon.DesignPattern.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Icon.DesignPattern.Tests.DependencyInjection
{
    [TestFixture]
    public class ApplicationDbContextTest
    {
        private ApplicationDbContext _context; 

        [OneTimeSetUp]
        public void Setup()
        {
            _context = ApplicationDbContextFactory.Init(AppSettings.DbContextSetting.ConnectionStringName);
        }

        [Test]
        public void Get_Products_Test()
        {
            var result = _context.Products.ToList(); 
        }
    }
}
