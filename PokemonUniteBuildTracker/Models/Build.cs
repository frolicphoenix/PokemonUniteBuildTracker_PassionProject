using System.ComponentModel.DataAnnotations;

namespace PokemonUniteBuildTracker.Models
{
    public class Build
    {
        [Key]
        public int BuildId { get; set; }

        // a build can have one pokemon

        // a build can have 3 (multiple) held items

        // a build can have one battle item
    }
}
