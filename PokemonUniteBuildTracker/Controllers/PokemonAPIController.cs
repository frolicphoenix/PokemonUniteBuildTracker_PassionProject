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

        public PokemonAPIController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("ListPokemons")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> ListPokemons()
        {
            var pokemonDTOs = await _pokemonService.ListPokemons();
            return Ok(pokemonDTOs);
        }

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
