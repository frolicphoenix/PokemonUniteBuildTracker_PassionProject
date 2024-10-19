using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonUniteBuildTracker.Data;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PokemonAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns list of all Pokémon in the database.
        /// </summary>
        /// <returns>
        /// A list of PokemonDTOs.
        /// </returns>
        /// <example>
        /// GET api/pokemonapi/listpokemons
        /// </example>
        [HttpGet("ListPokemons")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> ListPokemons()
        {
            var pokemons = await _context.Pokemons.ToListAsync();

            var pokemonDTOs = pokemons.Select(p => new PokemonDTO
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
            }).ToList();

            return Ok(pokemonDTOs);
        }

        /// <summary>
        /// Finds the Pokémon by its ID and returns the Pokémon data.
        /// </summary>
        /// <param name="id">Primary key for Pokémon in the database.</param>
        /// <returns>
        /// A PokemonDTO.
        /// </returns>
        /// <example>
        /// GET api/pokemonapi/findpokemon/3
        /// </example>
        [HttpGet("FindPokemon/{id}")]
        public async Task<ActionResult<PokemonDTO>> FindPokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonDTO = new PokemonDTO
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

            return Ok(pokemonDTO);
        }

        /// <summary>
        /// Creates a new Pokémon.
        /// </summary>
        /// <param name="pokemonDTO">Information to create a new Pokémon.</param>
        /// <returns>
        /// The created PokemonDTO.
        /// </returns>
        /// <example>
        /// POST api/pokemonapi/createpokemon
        /// </example>
        [HttpPost("CreatePokemon")]
        public async Task<ActionResult<PokemonDTO>> CreatePokemon(PokemonDTO pokemonDTO)
        {
            if (pokemonDTO == null)
            {
                return BadRequest();
            }

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

            // Update the DTO with the generated PokemonId
            pokemonDTO.PokemonId = pokemon.PokemonId;

            return CreatedAtAction(nameof(FindPokemon), new { id = pokemon.PokemonId }, pokemonDTO);
        }

        /// <summary>
        /// Updates a Pokémon.
        /// </summary>
        /// <param name="id">The ID of the Pokémon to update.</param>
        /// <param name="pokemonDTO">Updated Pokémon information.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// PUT api/pokemonapi/update/5
        /// </example>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.PokemonId)
            {
                return BadRequest();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

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
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Deletes the Pokémon from the database.
        /// </summary>
        /// <param name="id">The ID of the Pokémon to be deleted.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// DELETE api/pokemonapi/delete/5
        /// </example>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokemonId == id);
        }
    }
}
