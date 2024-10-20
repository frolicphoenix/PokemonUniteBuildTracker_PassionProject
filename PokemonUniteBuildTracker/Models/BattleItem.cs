using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.Models
{
    public class BattleItem
    {
        [Key]
        public int BattleItemId { get; set; }
        public string BattleItemImgLink { get; set; }
        public string BattleItemName { get; set; }
        public int BattleItemHP { get; set; }
        public int BattleItemAttack { get; set; }
        public int BattleItemDefense { get; set; }
        public int BattleItemSpAttack { get; set; }
        public int BattleItemSpDefense { get; set; }
        public int BattleItemCritRate { get; set; }
        public int BattleItemCDR {  get; set; }
        public int BattleItemLifesteal {  get; set; }
        public int BattleItemAttackSpeed { get; set; }
        public int BattleItemMoveSpeed { get; set; }

        // a battle item can be attached to multiple pokemon
        public ICollection<Pokemon>? Pokemons { get; set; }

        // a battle item can be attached to multiple builds
        /*public ICollection<Build> Builds { get; set; }*/

    }
    public class BattleItemDTO
    {
        public int BattleItemId { get; set; }
        public string BattleItemImgLink { get; set; }
        public string BattleItemName { get; set; }
        public int BattleItemHP { get; set; }
        public int BattleItemAttack { get; set; }
        public int BattleItemDefense { get; set; }
        public int BattleItemSpAttack { get; set; }
        public int BattleItemSpDefense { get; set; }
        public int BattleItemCritRate { get; set; }
        public int BattleItemCDR { get; set; }
        public int BattleItemLifesteal { get; set; }
        public int BattleItemAttackSpeed { get; set; }
        public int BattleItemMoveSpeed { get; set; }
    }
}
