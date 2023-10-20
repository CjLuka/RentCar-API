using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6444a22-838a-4173-bcfe-365637e81297", "AQAAAAIAAYagAAAAEDZIwVAMU9BZQn2I/51wWs/bQzHCEjWXPYeD7yp7l0ZLXFhaYMylT7Usbvtb69Idew==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAppId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27d540b0-ccc7-43b2-9163-f888e8cbb439", "AQAAAAIAAYagAAAAEIaTub8Cj1QAmXY0zRwD++fPtwFuvX3e705M8/RsuvT50nYKSc5pj1L+ZLqAxnaa7Q==" });
        }
    }
}
