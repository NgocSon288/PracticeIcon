using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Icon.Middleware.DataAccess.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3a4834eb-7cac-4ab7-9264-2f3de64691bb"), new Guid("f5db37ae-5f02-4eda-8724-c2ca79be046f") },
                    { new Guid("c7b995fe-e667-495e-93cf-7c81afdb3c04"), new Guid("f222c1f7-53fb-4c1b-9c6d-71757abefbc9") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CellPhone" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tablet" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Smartwatch" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3a4834eb-7cac-4ab7-9264-2f3de64691bb"), "3c1c4b2b-61bd-47ec-af02-41c1838dae51", "Administrator role", "admin", "admin" },
                    { new Guid("c7b995fe-e667-495e-93cf-7c81afdb3c04"), "a7293979-f638-4c39-94f9-d56b351b14ca", "Member role", "member", "member" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("f5db37ae-5f02-4eda-8724-c2ca79be046f"), 0, 0, "e9da5ac5-796f-44f9-bd99-592924290da9", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "18521694@gm.uit.edu.vn", true, false, null, null, "18521694@gm.uit.edu.vn", "admin", "AQAAAAEAACcQAAAAEAtJUeHL4jk9KGrHA025DSWH80BPtWznARBWQYi8ey7BmB1fHXJ4pPes2ppsRA30Sw==", null, null, false, "", false, "admin" },
                    { new Guid("f222c1f7-53fb-4c1b-9c6d-71757abefbc9"), 0, 0, "2a40232f-5987-4a4d-ac81-7e496e7a9048", new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dqvinh@gm.uit.edu.vn", true, false, null, null, "dqvinh@gm.uit.edu.vn", "member", "AQAAAAEAACcQAAAAEOMZqOYbVjRbSNje9euRUSzYeYWN516U2BQ5oSVqGAfC2wqXmX3ZMEV8GcRcVYjbPA==", null, null, false, "", false, "member" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CellPhone 1" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CellPhone 1" },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop 1" },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop 1" },
                    { 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tablet 1" },
                    { 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tablet 1" },
                    { 7, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Smartwatch 1" },
                    { 8, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Smartwatch 1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c7b995fe-e667-495e-93cf-7c81afdb3c04"), new Guid("f222c1f7-53fb-4c1b-9c6d-71757abefbc9") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a4834eb-7cac-4ab7-9264-2f3de64691bb"), new Guid("f5db37ae-5f02-4eda-8724-c2ca79be046f") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a4834eb-7cac-4ab7-9264-2f3de64691bb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c7b995fe-e667-495e-93cf-7c81afdb3c04"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f222c1f7-53fb-4c1b-9c6d-71757abefbc9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5db37ae-5f02-4eda-8724-c2ca79be046f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
