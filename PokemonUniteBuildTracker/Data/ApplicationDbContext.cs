using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // pokemon.cs will map to a pokemon table
        public DbSet<Pokemon> Pokemons { get; set; }

        // battleitem.cs will map to battleitems table
        public DbSet<BattleItem> BattleItems { get; set; }

        // helditem.cs will map to helditems table
        public DbSet<HeldItem> HeldItems { get; set; }

        //build.cs will map to builds table
        public DbSet<Build> Builds { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
