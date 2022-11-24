using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_IngredientsId",
                table: "Pizze",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Ingredients_IngredientsId",
                table: "Pizze",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Ingredients_IngredientsId",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_IngredientsId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Pizze");
        }
    }
}
