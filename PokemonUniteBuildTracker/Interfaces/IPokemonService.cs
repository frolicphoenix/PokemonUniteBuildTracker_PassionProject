using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    //Defines the contract for Pokémon-related operations.
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDTO>> ListPokemons();
        Task<PokemonDTO> FindPokemon(int id);
        Task<PokemonDTO> CreatePokemon(PokemonDTO pokemonDTO);
        Task<bool> UpdatePokemon(int id, PokemonDTO pokemonDTO);
        Task<bool> DeletePokemon(int id);
    }
}