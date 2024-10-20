// ViewModels/BuildViewModel.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.ViewModels
{
    public class BuildViewModel
    {
        [Display(Name = "Select Pokémon")]
        public int? SelectedPokemonId { get; set; }
        public List<PokemonViewModel> AvailablePokemons { get; set; }

        [Display(Name = "Select Held Items")]
        public List<int> SelectedHeldItemIds { get; set; } = new List<int>();
        public List<HeldItemViewModel> AvailableHeldItems { get; set; }

        [Display(Name = "Select Battle Item")]
        public int? SelectedBattleItemId { get; set; }
        public List<BattleItemViewModel> AvailableBattleItems { get; set; }

        // Base stats of the selected Pokémon
        public PokemonViewModel SelectedPokemon { get; set; }

        // Calculated stats
        public int TotalHP { get; set; }
        public int TotalAttack { get; set; }
        public int TotalDefense { get; set; }
        public int TotalSpAttack { get; set; }
        public int TotalSpDefense { get; set; }
        public int TotalCritRate { get; set; }
        public int TotalCDR { get; set; }
        public int TotalLifesteal { get; set; }
        public int TotalAttackSpeed { get; set; }
        public int TotalMoveSpeed { get; set; }
    }
}
