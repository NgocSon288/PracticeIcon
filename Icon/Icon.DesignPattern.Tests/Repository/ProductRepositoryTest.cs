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
    public class ProductRepositoryTest : BaseRepositoryTest<Product, ProductRepository>
    {

    }
}
