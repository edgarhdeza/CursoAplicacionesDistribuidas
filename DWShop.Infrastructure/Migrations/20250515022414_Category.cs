using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Catalog");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Catalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CategoryId",
                table: "Catalog",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_CategoryId",
                table: "Catalog",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_CategoryId",
                table: "Catalog");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_CategoryId",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Catalog");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Catalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
