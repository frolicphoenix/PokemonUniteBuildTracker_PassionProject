using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.Models
{
    public class Build
    {
        // not sure if build model is needed, i added it just in case for my own future reference

        [Key]
        public int BuildId { get; set; }

        // a build can have one pokemon
        /*public int PokemonId { get; set; }
        public virtual Pokemon Pokemon { get; set; }*/

        // a build can have 3 (multiple) held items
        /*public IEnumerable<HeldItem> HeldItems { get; set; }*/

        // a build can have one battle item
        /*public IEnumerable<BattleItem> BattleItems { get; set; }*/
    }
}
