using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class CategoryPizzeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categories_CategoryId",
                table: "Pizze");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Pizze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categories_CategoryId",
                table: "Pizze",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categories_CategoryId",
                table: "Pizze");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Pizze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categories_CategoryId",
                table: "Pizze",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
