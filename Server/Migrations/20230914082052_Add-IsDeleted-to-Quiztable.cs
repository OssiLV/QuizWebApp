using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedtoQuiztable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Quizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4c49a99d-8481-4267-af9d-efb52db074d3"), "1", "Admin", "ADMIN" },
                    { new Guid("78068413-55cc-44bf-9215-be02989dec25"), "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5977691c-8c77-492f-a1d0-77a7fdac1331"), "Medium" },
                    { new Guid("ac9f7a7e-4f6e-45a2-9c0b-453b1ae101aa"), "Hard" },
                    { new Guid("b5135715-e8c2-40ad-803c-8225fb513e81"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c49a99d-8481-4267-af9d-efb52db074d3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("78068413-55cc-44bf-9215-be02989dec25"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5977691c-8c77-492f-a1d0-77a7fdac1331"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ac9f7a7e-4f6e-45a2-9c0b-453b1ae101aa"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b5135715-e8c2-40ad-803c-8225fb513e81"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Quizzes");

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
    }
}
