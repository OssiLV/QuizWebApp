using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptiontoQuiztable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52272e12-1ff2-4ae8-9c49-b1e06dff558d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e8d6903e-1702-447a-9d09-281656766b62"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8cba59d0-209d-4aa9-938a-f9271a79196b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9835ecab-30a7-4d8b-9a32-a68e6f95f4dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b1e1c20c-7169-41ef-86db-ccb46ef4e052"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0be148d6-4dcf-43b4-a235-22e57bbdddc8"), "2", "User", "USER" },
                    { new Guid("12b0a20f-3e10-4f64-a7f2-91bc26b0ea38"), "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("79cfe8ae-416e-4bb5-bae0-063f9d31db8d"), "Easy" },
                    { new Guid("c613ffa6-0761-4565-8d0a-2b2fbe67a223"), "Hard" },
                    { new Guid("f1d277a9-3a5a-4a7b-8e16-60bd1ef66fe5"), "Medium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0be148d6-4dcf-43b4-a235-22e57bbdddc8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("12b0a20f-3e10-4f64-a7f2-91bc26b0ea38"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79cfe8ae-416e-4bb5-bae0-063f9d31db8d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c613ffa6-0761-4565-8d0a-2b2fbe67a223"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f1d277a9-3a5a-4a7b-8e16-60bd1ef66fe5"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quizzes");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("52272e12-1ff2-4ae8-9c49-b1e06dff558d"), "2", "User", "USER" },
                    { new Guid("e8d6903e-1702-447a-9d09-281656766b62"), "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8cba59d0-209d-4aa9-938a-f9271a79196b"), "Easy" },
                    { new Guid("9835ecab-30a7-4d8b-9a32-a68e6f95f4dc"), "Hard" },
                    { new Guid("b1e1c20c-7169-41ef-86db-ccb46ef4e052"), "Medium" }
                });
        }
    }
}
