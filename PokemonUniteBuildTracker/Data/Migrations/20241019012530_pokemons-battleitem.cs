using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokemonsbattleitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattleItemId",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_BattleItemId",
                table: "Pokemons",
                column: "BattleItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_BattleItems_BattleItemId",
                table: "Pokemons",
                column: "BattleItemId",
                principalTable: "BattleItems",
                principalColumn: "BattleItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_BattleItems_BattleItemId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_BattleItemId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "BattleItemId",
                table: "Pokemons");
        }
    }
}
