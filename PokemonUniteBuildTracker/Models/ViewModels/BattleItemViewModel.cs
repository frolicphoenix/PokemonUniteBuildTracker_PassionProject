using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.ViewModels
{
    public class BattleItemViewModel
    {
        public int BattleItemId { get; set; }

        [Display(Name = "Image URL")]
        public string BattleItemImgLink { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string BattleItemName { get; set; }

        // Stats
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
