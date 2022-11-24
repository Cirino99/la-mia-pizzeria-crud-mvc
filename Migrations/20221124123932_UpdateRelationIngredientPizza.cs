using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationIngredientPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Ingredients_IngredientsId",
                table: "Pizze");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_IngredientsId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Pizze");

            migrationBuilder.CreateTable(
                name: "IngredientPizza",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    PizzeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPizza", x => new { x.IngredientsId, x.PizzeId });
                    table.ForeignKey(
                        name: "FK_IngredientPizza_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPizza_Pizze_PizzeId",
                        column: x => x.PizzeId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_PizzeId",
                table: "IngredientPizza",
                column: "PizzeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientPizza");

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Pizze",
                type: "int",
                nullable: true);

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
    }
}
