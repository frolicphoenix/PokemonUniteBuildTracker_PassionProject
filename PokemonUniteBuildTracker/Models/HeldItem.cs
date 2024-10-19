using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.Models
{
    public class HeldItem
    {
        [Key]
        public int HeldItemId { get; set; }
        public int HeldItemImgLink { get; set; }
        public string HeldItemName { get; set; }
        public int HeldItemHP { get; set; }
        public int HeldItemAttack { get; set; }
        public int HeldItemDefense { get; set; }
        public int HeldItemSpAttack { get; set; }
        public int HeldItemSpDefense { get; set; }
        public int HeldItemCritRate { get; set; }
        public int HeldItemCDR {  get; set; }
        public int HeldItemLifesteal {  get; set; }
        public int HeldItemAttackSpeed { get; set; }
        public int HeldItemMoveSpeed { get; set; }

        // a held item can be attached to multiple pokemons
        public ICollection<Pokemon> Pokemons { get; set; }

        // a held item can be attached to multiple buildss
        /*public ICollection<Build> Builds { get; set; }*/

    }
}
