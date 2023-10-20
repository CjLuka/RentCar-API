using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e931eb5-65dd-4223-85d7-19d7e56856a0", "AQAAAAIAAYagAAAAEFlBj807cY2+2+9ppmw2802bYv9PtvYSmKzl5KQRQd0S75uqOZdGUe4zyzKAniqg6Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb60e451-c244-4714-a191-b818c0a6e6a6", "AQAAAAIAAYagAAAAEGRvJ6QDn4t3f8F2WYx+Z2e7U5CkE7IT8IFeh0wc+K6CF+mRX452FbarpMwcd9bAwg==" });
        }
    }
}
