using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.ViewModels
{
    //ViewModel representing a Held Item for display and input in views.
    public class HeldItemViewModel
    {
        public int HeldItemId { get; set; }

        [Display(Name = "Image URL")]
        public string HeldItemImgLink { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string HeldItemName { get; set; }

        // Stats
        public int HeldItemHP { get; set; }
        public int HeldItemAttack { get; set; }
        public int HeldItemDefense { get; set; }
        public int HeldItemSpAttack { get; set; }
        public int HeldItemSpDefense { get; set; }
        public int HeldItemCritRate { get; set; }
        public int HeldItemCDR { get; set; }
        public int HeldItemLifesteal { get; set; }
        public int HeldItemAttackSpeed { get; set; }
        public int HeldItemMoveSpeed { get; set; }
    }
}
