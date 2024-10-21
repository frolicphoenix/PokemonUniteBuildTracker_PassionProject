using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.ViewModels
{
    //ViewModel representing a Pokémon for display and input in views.
    public class PokemonViewModel
    {
        public int PokemonId { get; set; }

        [Display(Name = "Image URL")]
        public string PokemonImgLink { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PokemonName { get; set; }

        [Display(Name = "Role")]
        public string PokemonRole { get; set; }

        [Display(Name = "Style")]
        public string PokemonStyle { get; set; }

        // Stats
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

        // Relationships
        /*[Display(Name = "Held Items")]
        public List<int> SelectedHeldItemIds { get; set; } = new List<int>();
        public List<HeldItemViewModel> AvailableHeldItems { get; set; }

        [Display(Name = "Battle Item")]
        public int? SelectedBattleItemId { get; set; }
        public List<BattleItemViewModel> AvailableBattleItems { get; set; }*/
    }
}
