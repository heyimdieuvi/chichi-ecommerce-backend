using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChiChiEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_categories_categoryid",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_shops_shopid",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_product_shopid",
                table: "products",
                newName: "IX_products_shopid");

            migrationBuilder.RenameIndex(
                name: "IX_product_categoryid",
                table: "products",
                newName: "IX_products_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_categoryid",
                table: "products",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_shops_shopid",
                table: "products",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "shopid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_categoryid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_shops_shopid",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_products_shopid",
                table: "product",
                newName: "IX_product_shopid");

            migrationBuilder.RenameIndex(
                name: "IX_products_categoryid",
                table: "product",
                newName: "IX_product_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_product_categories_categoryid",
                table: "product",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_product_shops_shopid",
                table: "product",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "shopid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
