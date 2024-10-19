using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class helditem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PokemonImgLink",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BattleItems",
                columns: table => new
                {
                    BattleItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleItemImgLink = table.Column<int>(type: "int", nullable: false),
                    BattleItemName = table.Column<int>(type: "int", nullable: false),
                    BattleItemHP = table.Column<int>(type: "int", nullable: false),
                    BattleItemAttack = table.Column<int>(type: "int", nullable: false),
                    BattleItemDefense = table.Column<int>(type: "int", nullable: false),
                    BattleItemSpAttack = table.Column<int>(type: "int", nullable: false),
                    BattleItemSpDefense = table.Column<int>(type: "int", nullable: false),
                    BattleItemCritRate = table.Column<int>(type: "int", nullable: false),
                    BattleItemCDR = table.Column<int>(type: "int", nullable: false),
                    BattleItemLifesteal = table.Column<int>(type: "int", nullable: false),
                    BattleItemAttackSpeed = table.Column<int>(type: "int", nullable: false),
                    BattleItemMoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleItems", x => x.BattleItemId);
                });

            migrationBuilder.CreateTable(
                name: "HeldItems",
                columns: table => new
                {
                    HeldItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeldItemImgLink = table.Column<int>(type: "int", nullable: false),
                    HeldItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeldItemHP = table.Column<int>(type: "int", nullable: false),
                    HeldItemAttack = table.Column<int>(type: "int", nullable: false),
                    HeldItemDefense = table.Column<int>(type: "int", nullable: false),
                    HeldItemSpAttack = table.Column<int>(type: "int", nullable: false),
                    HeldItemSpDefense = table.Column<int>(type: "int", nullable: false),
                    HeldItemCritRate = table.Column<int>(type: "int", nullable: false),
                    HeldItemCDR = table.Column<int>(type: "int", nullable: false),
                    HeldItemLifesteal = table.Column<int>(type: "int", nullable: false),
                    HeldItemAttackSpeed = table.Column<int>(type: "int", nullable: false),
                    HeldItemMoveSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeldItems", x => x.HeldItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleItems");

            migrationBuilder.DropTable(
                name: "HeldItems");

            migrationBuilder.DropColumn(
                name: "PokemonImgLink",
                table: "Pokemons");
        }
    }
}
