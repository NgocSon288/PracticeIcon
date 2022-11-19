using Icon.DesignPattern.Common;
using Icon.DesignPattern.DataAccess;
using Icon.DesignPattern.DataAccess.Models;
using Icon.DesignPattern.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Icon.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize DI
            var serviceProvider = ServiceContainer.InitDependencyInjection();

            // Because the main Program that can not be used, so we need to create another program as the main
            // For easy to Test
            var anotherProgram = serviceProvider.GetService<AnotherProgram>();
            anotherProgram.Main();
        }
    }

    // only use to demo

    public interface IProductRepo
    {
        List<Product> Gets();
    }
    public class ProductRepo: IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Gets()
        {
            return _context.Products
                   .Include(e => e.Category)
                   .ToList();
        }
    }
}
