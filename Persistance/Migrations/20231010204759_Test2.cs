using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_UserAppId1",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_UserAppId1",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UserAppId1",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27d540b0-ccc7-43b2-9163-f888e8cbb439", "AQAAAAIAAYagAAAAEIaTub8Cj1QAmXY0zRwD++fPtwFuvX3e705M8/RsuvT50nYKSc5pj1L+ZLqAxnaa7Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAppId1",
                table: "Rents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e931eb5-65dd-4223-85d7-19d7e56856a0", "AQAAAAIAAYagAAAAEFlBj807cY2+2+9ppmw2802bYv9PtvYSmKzl5KQRQd0S75uqOZdGUe4zyzKAniqg6Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserAppId1",
                table: "Rents",
                column: "UserAppId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_UserAppId1",
                table: "Rents",
                column: "UserAppId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
