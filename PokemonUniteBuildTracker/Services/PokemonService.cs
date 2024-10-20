using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonUniteBuildTracker.Data;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly ApplicationDbContext _context;

        public PokemonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PokemonDTO>> ListPokemons()
        {
            var pokemons = await _context.Pokemons.ToListAsync();
            return pokemons.Select(p => new PokemonDTO
            {
                PokemonId = p.PokemonId,
                PokemonImgLink = p.PokemonImgLink,
                PokemonName = p.PokemonName,
                PokemonRole = p.PokemonRole,
                PokemonStyle = p.PokemonStyle,
                PokemonHP = p.PokemonHP,
                PokemonAttack = p.PokemonAttack,
                PokemonDefense = p.PokemonDefense,
                PokemonSpAttack = p.PokemonSpAttack,
                PokemonSpDefense = p.PokemonSpDefense,
                PokemonCritRate = p.PokemonCritRate,
                PokemonCDR = p.PokemonCDR,
                PokemonLifesteal = p.PokemonLifesteal,
                PokemonAttackSpeed = p.PokemonAttackSpeed,
                PokemonMoveSpeed = p.PokemonMoveSpeed
            });
        }

        public async Task<PokemonDTO> FindPokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return null;

            return new PokemonDTO
            {
                PokemonId = pokemon.PokemonId,
                PokemonImgLink = pokemon.PokemonImgLink,
                PokemonName = pokemon.PokemonName,
                PokemonRole = pokemon.PokemonRole,
                PokemonStyle = pokemon.PokemonStyle,
                PokemonHP = pokemon.PokemonHP,
                PokemonAttack = pokemon.PokemonAttack,
                PokemonDefense = pokemon.PokemonDefense,
                PokemonSpAttack = pokemon.PokemonSpAttack,
                PokemonSpDefense = pokemon.PokemonSpDefense,
                PokemonCritRate = pokemon.PokemonCritRate,
                PokemonCDR = pokemon.PokemonCDR,
                PokemonLifesteal = pokemon.PokemonLifesteal,
                PokemonAttackSpeed = pokemon.PokemonAttackSpeed,
                PokemonMoveSpeed = pokemon.PokemonMoveSpeed
            };
        }

        public async Task<PokemonDTO> CreatePokemon(PokemonDTO pokemonDTO)
        {
            var pokemon = new Pokemon
            {
                PokemonImgLink = pokemonDTO.PokemonImgLink,
                PokemonName = pokemonDTO.PokemonName,
                PokemonRole = pokemonDTO.PokemonRole,
                PokemonStyle = pokemonDTO.PokemonStyle,
                PokemonHP = pokemonDTO.PokemonHP,
                PokemonAttack = pokemonDTO.PokemonAttack,
                PokemonDefense = pokemonDTO.PokemonDefense,
                PokemonSpAttack = pokemonDTO.PokemonSpAttack,
                PokemonSpDefense = pokemonDTO.PokemonSpDefense,
                PokemonCritRate = pokemonDTO.PokemonCritRate,
                PokemonCDR = pokemonDTO.PokemonCDR,
                PokemonLifesteal = pokemonDTO.PokemonLifesteal,
                PokemonAttackSpeed = pokemonDTO.PokemonAttackSpeed,
                PokemonMoveSpeed = pokemonDTO.PokemonMoveSpeed
            };

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            pokemonDTO.PokemonId = pokemon.PokemonId;
            return pokemonDTO;
        }

        public async Task<bool> UpdatePokemon(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.PokemonId) return false;

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return false;

            pokemon.PokemonImgLink = pokemonDTO.PokemonImgLink;
            pokemon.PokemonName = pokemonDTO.PokemonName;
            pokemon.PokemonRole = pokemonDTO.PokemonRole;
            pokemon.PokemonStyle = pokemonDTO.PokemonStyle;
            pokemon.PokemonHP = pokemonDTO.PokemonHP;
            pokemon.PokemonAttack = pokemonDTO.PokemonAttack;
            pokemon.PokemonDefense = pokemonDTO.PokemonDefense;
            pokemon.PokemonSpAttack = pokemonDTO.PokemonSpAttack;
            pokemon.PokemonSpDefense = pokemonDTO.PokemonSpDefense;
            pokemon.PokemonCritRate = pokemonDTO.PokemonCritRate;
            pokemon.PokemonCDR = pokemonDTO.PokemonCDR;
            pokemon.PokemonLifesteal = pokemonDTO.PokemonLifesteal;
            pokemon.PokemonAttackSpeed = pokemonDTO.PokemonAttackSpeed;
            pokemon.PokemonMoveSpeed = pokemonDTO.PokemonMoveSpeed;

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id)) return false;
                else throw;
            }
        }

        public async Task<bool> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null) return false;

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokemonId == id);
        }
    }
}
