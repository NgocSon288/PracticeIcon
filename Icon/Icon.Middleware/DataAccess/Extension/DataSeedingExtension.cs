using Icon.Middleware.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Icon.Middleware.DataAccess.Extension
{
    public static class DataSeedingExtension
    {
        public static void Seed(this ModelBuilder modelBuilder, IConfiguration configuration)
        {
            // Get data from appsetting file
            var categories = GetCategoriesWith_KeyValueItem(configuration);
            var products = GetProductsWith_ArrayItem(configuration);

            // Seeding data for IdentityData
            modelBuilder.SeedingIdentityData(configuration);

            // Seeding data to database
            modelBuilder.Entity<Category>().HasData(
                categories
            );
            modelBuilder.Entity<Product>().HasData(
                products
            );
        }

        public static void SeedingIdentityData(this ModelBuilder modelBuilde, IConfiguration configuration)
        {
            List<AppRole> appRoles = new List<AppRole>();
            List<AppUser> appUsers = new List<AppUser>();
            List<IdentityUserRole<Guid>> identityUserRoles = new List<IdentityUserRole<Guid>>();

            var appRolesData = configuration.GetSection("DataSeed:AppRoles");
            var appUsersData = configuration.GetSection("DataSeed:AppUsers");
            var identityUserRolesData = configuration.GetSection("DataSeed:IdentityUserRoles");

            foreach (IConfigurationSection section in appRolesData.GetChildren())
            {
                var id = section.GetSection("id").Value;
                var name = section.GetSection("name").Value;
                var normalizedName = section.GetSection("normalizedName").Value;
                var description = section.GetSection("description").Value;

                appRoles.Add(new AppRole()
                {
                    Id = new Guid(id),
                    Name = name,
                    NormalizedName = normalizedName,
                    Description = description
                });
            }

            var hasher = new PasswordHasher<AppUser>();
            foreach (IConfigurationSection section in appUsersData.GetChildren())
            {
                var id = section.GetSection("id").Value;
                var username = section.GetSection("username").Value;
                var normalizedUserName = section.GetSection("normalizedUserName").Value;
                var email = section.GetSection("email").Value;
                var normalizedEmail = section.GetSection("normalizedEmail").Value;
                var emailConfirmed = section.GetSection("emailConfirmed").Value;
                var password = section.GetSection("password").Value;
                var securityStamp = section.GetSection("securityStamp").Value;
                var dob = section.GetSection("dob").Value;

                appUsers.Add(new AppUser
                {
                    Id = new Guid(id),
                    UserName = username,
                    NormalizedUserName = normalizedUserName,
                    Email = email,
                    NormalizedEmail = normalizedEmail,
                    EmailConfirmed = bool.Parse(emailConfirmed),
                    PasswordHash = hasher.HashPassword(null, password),
                    SecurityStamp = securityStamp,
                    Dob = DateTime.Parse(dob)
                });
            }

            foreach (IConfigurationSection section in identityUserRolesData.GetChildren())
            {
                var roleid = section.GetSection("roleid").Value;
                var userid = section.GetSection("userid").Value; 

                identityUserRoles.Add(new IdentityUserRole<Guid>
                {
                    RoleId = new Guid(roleid),
                    UserId = new Guid(userid)
                });
            }

            modelBuilde.Entity<AppRole>().HasData(appRoles);
            modelBuilde.Entity<AppUser>().HasData(appUsers);
            modelBuilde.Entity<IdentityUserRole<Guid>>().HasData(identityUserRoles);
        }

        public static void SeedingIdentityData_HardCode(this ModelBuilder modelBuilde, IConfiguration configuration)
        {
            List<AppRole> appRoles = new List<AppRole>();
            List<AppUser> appUsers = new List<AppUser>();
            List<IdentityUserRole<Guid>> identityUserRoles = new List<IdentityUserRole<Guid>>();

            // any guid
            var roleId_Admin = new Guid("3A4834EB-7CAC-4AB7-9264-2F3DE64691BB");
            var userId_Admin = new Guid("F5DB37AE-5F02-4EDA-8724-C2CA79BE046F");
            appRoles.Add(new AppRole
            {
                Id = roleId_Admin,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            appUsers.Add(new AppUser
            {
                Id = userId_Admin,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "18521694@gm.uit.edu.vn",
                NormalizedEmail = "18521694@gm.uit.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123x@X"),
                SecurityStamp = string.Empty,
                Dob = new DateTime(2020, 01, 31)
            });

            identityUserRoles.Add(new IdentityUserRole<Guid>
            {
                RoleId = roleId_Admin,
                UserId = userId_Admin
            });

            modelBuilde.Entity<AppRole>().HasData(appRoles);
            modelBuilde.Entity<AppUser>().HasData(appUsers);
            modelBuilde.Entity<IdentityUserRole<Guid>>().HasData(identityUserRoles);
        }

        public static IEnumerable<Product> GetProductsWith_ArrayItem(IConfiguration configuration)
        {
            var productsData = configuration.GetSection("DataSeed:Products");

            foreach (IConfigurationSection section in productsData.GetChildren())
            {
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

        public static IEnumerable<Category> GetCategoriesWith_KeyValueItem(IConfiguration configuration)
        {
            var categoriesData = configuration.GetSection("DataSeed:Categories");

            foreach (IConfigurationSection section in categoriesData.GetChildren())
            {
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
