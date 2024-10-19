using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.Models
{
    public class Pokemon
    {
        // pokemon table is registered with a PK
        [Key]
        public int PokemonId { get; set; }
        public string PokemonImgLink { get; set; }
        public string PokemonName { get; set; }
        public string PokemonRole { get; set; }
        public string PokemonStyle { get; set; }
        public int PokemonHP { get; set; }
        public int PokemonAttack { get; set; }
        public int PokemonDefense { get; set; }
        public int PokemonSpAttack { get; set; }
        public int PokemonSpDefense { get; set; }
        public int PokemonCritRate { get; set; }
        public int PokemonCDR { get; set; }
        public int PokemonLifesteal { get; set; }
        public int PokemonAttackSpeed { get; set; }
        public int PokemonMoveSpeed { get; set; }


    }
}
