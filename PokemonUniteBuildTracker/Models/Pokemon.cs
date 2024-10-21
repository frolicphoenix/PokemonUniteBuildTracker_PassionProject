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

        // a pokemon can have 3 (multiple) held items
        public ICollection<HeldItem> HeldItems { get; set; }

        // a pokemon can have one battle item
        public ICollection<BattleItem> BattleItems { get; set; }

        // a pokemon can have many builds
       /* public ICollection<Build> Builds { get; set; }*/

    }

    public class PokemonDTO
    {
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

        // for future implementations
        /*public List<HeldItemDTO> HeldItems { get; set; }
        public BattleItemDTO BattleItem { get; set; }*/
    }

}
