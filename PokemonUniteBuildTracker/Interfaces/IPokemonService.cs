using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDTO>> GetAllPokemonsAsync();
        Task<PokemonDTO> GetPokemonByIdAsync(int id);
        Task<PokemonDTO> CreatePokemonAsync(PokemonDTO pokemonDTO);
        Task<bool> UpdatePokemonAsync(int id, PokemonDTO pokemonDTO);
        Task<bool> DeletePokemonAsync(int id);

        // Relational CRUD methods
        Task<bool> AddHeldItemToPokemonAsync(int pokemonId, int heldItemId);
        Task<bool> RemoveHeldItemFromPokemonAsync(int pokemonId, int heldItemId);
        Task<bool> AddBattleItemToPokemonAsync(int pokemonId, int battleItemId);
        Task<bool> RemoveBattleItemFromPokemonAsync(int pokemonId, int battleItemId);
    }
}
