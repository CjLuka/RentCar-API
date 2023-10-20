using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAppId",
                table: "Rents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87269d5a-f157-4cad-af09-099ad187ea05", "AQAAAAIAAYagAAAAEDVqu3aOehTmRZh0bhG+skpNbSmDMZFzUwpNgMd2E/tixMa/iUnd9hVr+st+AhcJBg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserAppId",
                table: "Rents",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_UserAppId",
                table: "Rents",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_UserAppId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_UserAppId",
                table: "Rents");

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
    }
}
