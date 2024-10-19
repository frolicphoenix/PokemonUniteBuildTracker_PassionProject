using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokemonbattleitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BattleItemPokemon",
                columns: table => new
                {
                    BattleItemsBattleItemId = table.Column<int>(type: "int", nullable: false),
                    PokemonsPokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleItemPokemon", x => new { x.BattleItemsBattleItemId, x.PokemonsPokemonId });
                    table.ForeignKey(
                        name: "FK_BattleItemPokemon_BattleItems_BattleItemsBattleItemId",
                        column: x => x.BattleItemsBattleItemId,
                        principalTable: "BattleItems",
                        principalColumn: "BattleItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleItemPokemon_Pokemons_PokemonsPokemonId",
                        column: x => x.PokemonsPokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleItemPokemon_PokemonsPokemonId",
                table: "BattleItemPokemon",
                column: "PokemonsPokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleItemPokemon");

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
    }
}
