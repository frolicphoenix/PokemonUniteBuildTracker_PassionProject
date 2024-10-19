using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokemonshelditems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeldItemPokemon",
                columns: table => new
                {
                    HeldItemsHeldItemId = table.Column<int>(type: "int", nullable: false),
                    PokemonsPokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeldItemPokemon", x => new { x.HeldItemsHeldItemId, x.PokemonsPokemonId });
                    table.ForeignKey(
                        name: "FK_HeldItemPokemon_HeldItems_HeldItemsHeldItemId",
                        column: x => x.HeldItemsHeldItemId,
                        principalTable: "HeldItems",
                        principalColumn: "HeldItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeldItemPokemon_Pokemons_PokemonsPokemonId",
                        column: x => x.PokemonsPokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeldItemPokemon_PokemonsPokemonId",
                table: "HeldItemPokemon",
                column: "PokemonsPokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeldItemPokemon");
        }
    }
}
