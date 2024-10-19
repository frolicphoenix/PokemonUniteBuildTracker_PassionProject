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

        public async Task<IEnumerable<PokemonDTO>> GetAllPokemonsAsync()
        {
            var pokemons = await _context.Pokemons.ToListAsync();
            var pokemonDTOs = pokemons.Select(p => MapToDTO(p)).ToList();
            return pokemonDTOs;
        }

        public async Task<PokemonDTO> GetPokemonByIdAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
                return null;

            return MapToDTO(pokemon);
        }

        public async Task<PokemonDTO> CreatePokemonAsync(PokemonDTO pokemonDTO)
        {
            var pokemon = MapToEntity(pokemonDTO);
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
            pokemonDTO.PokemonId = pokemon.PokemonId;
            return pokemonDTO;
        }

        public async Task<bool> UpdatePokemonAsync(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.PokemonId)
                return false;

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
                return false;

            // Update properties
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
                if (!PokemonExists(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
                return false;

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
            return true;
        }

        // Relational CRUD methods

        public async Task<bool> AddHeldItemToPokemonAsync(int pokemonId, int heldItemId)
        {
            var pokemon = await _context.Pokemons
                .Include(p => p.HeldItems)
                .FirstOrDefaultAsync(p => p.PokemonId == pokemonId);
            if (pokemon == null)
                return false;

            var heldItem = await _context.HeldItems.FindAsync(heldItemId);
            if (heldItem == null)
                return false;

            if (pokemon.HeldItems == null)
                pokemon.HeldItems = new List<HeldItem>();

            pokemon.HeldItems.Add(heldItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveHeldItemFromPokemonAsync(int pokemonId, int heldItemId)
        {
            var pokemon = await _context.Pokemons
                .Include(p => p.HeldItems)
                .FirstOrDefaultAsync(p => p.PokemonId == pokemonId);
            if (pokemon == null || pokemon.HeldItems == null)
                return false;

            var heldItem = pokemon.HeldItems.FirstOrDefault(h => h.HeldItemId == heldItemId);
            if (heldItem == null)
                return false;

            pokemon.HeldItems.Remove(heldItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddBattleItemToPokemonAsync(int pokemonId, int battleItemId)
        {
            var pokemon = await _context.Pokemons
                .Include(p => p.BattleItems)
                .FirstOrDefaultAsync(p => p.PokemonId == pokemonId);
            if (pokemon == null)
                return false;

            var battleItem = await _context.BattleItems.FindAsync(battleItemId);
            if (battleItem == null)
                return false;

            if (pokemon.BattleItems == null)
                pokemon.BattleItems = new List<BattleItem>();

            pokemon.BattleItems.Add(battleItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveBattleItemFromPokemonAsync(int pokemonId, int battleItemId)
        {
            var pokemon = await _context.Pokemons
                .Include(p => p.BattleItems)
                .FirstOrDefaultAsync(p => p.PokemonId == pokemonId);
            if (pokemon == null || pokemon.BattleItems == null)
                return false;

            var battleItem = pokemon.BattleItems.FirstOrDefault(b => b.BattleItemId == battleItemId);
            if (battleItem == null)
                return false;

            pokemon.BattleItems.Remove(battleItem);
            await _context.SaveChangesAsync();
            return true;
        }

        // Helper methods

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokemonId == id);
        }

        private PokemonDTO MapToDTO(Pokemon pokemon)
        {
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

        private Pokemon MapToEntity(PokemonDTO dto)
        {
            return new Pokemon
            {
                PokemonImgLink = dto.PokemonImgLink,
                PokemonName = dto.PokemonName,
                PokemonRole = dto.PokemonRole,
                PokemonStyle = dto.PokemonStyle,
                PokemonHP = dto.PokemonHP,
                PokemonAttack = dto.PokemonAttack,
                PokemonDefense = dto.PokemonDefense,
                PokemonSpAttack = dto.PokemonSpAttack,
                PokemonSpDefense = dto.PokemonSpDefense,
                PokemonCritRate = dto.PokemonCritRate,
                PokemonCDR = dto.PokemonCDR,
                PokemonLifesteal = dto.PokemonLifesteal,
                PokemonAttackSpeed = dto.PokemonAttackSpeed,
                PokemonMoveSpeed = dto.PokemonMoveSpeed
            };
        }
    }
}
