using Icon.DesignPattern.Common;
using Icon.DesignPattern.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Icon.DesignPattern.DataAccess.Extensions
{
    public static class DataSeedingExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Console.WriteLine($"Start: Seeding data dated {DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}");
            // Get data from appsetting file
            var categories = GetCategoriesWith_KeyValueItem();
            var products = GetProductsWith_ArrayItem();

            // Seeding data to database
            modelBuilder.Entity<Category>().HasData(
                categories
            );
            modelBuilder.Entity<Product>().HasData(
                products
            );

            //Console.WriteLine($"End: Seeding data dated {DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}");
        }

        public static IEnumerable<Product> GetProductsWith_ArrayItem()
        {
            IConfiguration configuration = AppConfiguration.GetConfiguration();
            var productsData = configuration.GetSection("DataSeed:Products");

            foreach (IConfigurationSection section in productsData.GetChildren())
            {
                // section === "[ 1, "CellPhone 1", 1 ]"
                // GetChildren =>  [ 1, "CellPhone 1", 1 ]
                var entireValue = section
                    .GetChildren()
                    .Select(e => e.Value)
                    .ToArray();

                yield return new Product()
                {
                    Id = Int32.Parse(entireValue[0]),
                    Name = entireValue[1],
                    CategoryId = Int32.Parse(entireValue[2])
                };
            }
        }

        public static IEnumerable<Category> GetCategoriesWith_KeyValueItem()
        {
            IConfiguration configuration = AppConfiguration.GetConfiguration();
            var categoriesData = configuration.GetSection("DataSeed:Categories");

            foreach (IConfigurationSection section in categoriesData.GetChildren())
            {
                // section === { "id": 3, "n": "Laptop" }
                // GetSection("id") => 3
                var id = section.GetSection("id").Value;
                var name = section.GetSection("n").Value;

                yield return new Category()
                {
                    Id = Int32.Parse(id),
                    Name = name
                };
            }
        }

    }
}
