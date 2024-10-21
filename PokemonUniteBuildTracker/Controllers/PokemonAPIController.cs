using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonAPIController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        // initializes a new instance of the class
        public PokemonAPIController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Returns list of all pokemon in the database
        /// </summary>
        /// <returns>
        /// A list of PokemonDTOs.
        /// </returns>
        /// <example>
        /// GET api/pokemonapi/listpokemons
        /// </example>
        [HttpGet(template:"ListPokemons")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> ListPokemons()
        {
            var pokemonDTOs = await _pokemonService.ListPokemons();
            return Ok(pokemonDTOs);
        }

        /// <summary>
        /// Finds the Pokémon by its ID and returns the Pokémon data.
        /// </summary>
        /// <param name="id">Primary key for Pokémon in the database.</param>
        /// <returns>A PokemonDTO.</returns>
        /// <example>
        /// GET api/pokemonapi/findpokemon/3
        /// </example> 
        [HttpGet("FindPokemon/{id}")]
        public async Task<ActionResult<PokemonDTO>> FindPokemon(int id)
        {
            var pokemonDTO = await _pokemonService.FindPokemon(id);
            if (pokemonDTO == null)
            {
                return NotFound();
            }
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

            var createdPokemon = await _pokemonService.CreatePokemon(pokemonDTO);
            return CreatedAtAction(nameof(FindPokemon), new { id = createdPokemon.PokemonId }, createdPokemon);
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

            var result = await _pokemonService.UpdatePokemon(id, pokemonDTO);
            if (!result)
            {
                return NotFound();
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
            var result = await _pokemonService.DeletePokemon(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
