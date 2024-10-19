using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonHP = table.Column<int>(type: "int", nullable: false),
                    PokemonAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonSpAttack = table.Column<int>(type: "int", nullable: false),
                    PokemonSpDefense = table.Column<int>(type: "int", nullable: false),
                    PokemonCritRate = table.Column<int>(type: "int", nullable: false),
                    PokemonCDR = table.Column<int>(type: "int", nullable: false),
                    PokemonLifesteal = table.Column<int>(type: "int", nullable: false),
                    PokemonAttackSpeed = table.Column<int>(type: "int", nullable: false),
                    PokemonMoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.PokemonId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
