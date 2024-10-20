using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class listingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingDBTable_CategoriesDBTable_CategoryId",
                table: "ListingDBTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDBTable_LocationDBTable_LocationId",
                table: "ListingDBTable");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "ListingDBTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ListingName",
                table: "ListingDBTable",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "ListingDBTable",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ListingDBTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDBTable_CategoriesDBTable_CategoryId",
                table: "ListingDBTable",
                column: "CategoryId",
                principalTable: "CategoriesDBTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDBTable_LocationDBTable_LocationId",
                table: "ListingDBTable",
                column: "LocationId",
                principalTable: "LocationDBTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingDBTable_CategoriesDBTable_CategoryId",
                table: "ListingDBTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDBTable_LocationDBTable_LocationId",
                table: "ListingDBTable");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "ListingDBTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ListingDBTable",
                keyColumn: "ListingName",
                keyValue: null,
                column: "ListingName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ListingName",
                table: "ListingDBTable",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ListingDBTable",
                keyColumn: "ImageUrl",
                keyValue: null,
                column: "ImageUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "ListingDBTable",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ListingDBTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDBTable_CategoriesDBTable_CategoryId",
                table: "ListingDBTable",
                column: "CategoryId",
                principalTable: "CategoriesDBTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDBTable_LocationDBTable_LocationId",
                table: "ListingDBTable",
                column: "LocationId",
                principalTable: "LocationDBTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
