using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeldItemAPIController : ControllerBase
    {
        private readonly IHeldItemService _heldItemService;

        public HeldItemAPIController(IHeldItemService heldItemService)
        {
            _heldItemService = heldItemService;
        }

        [HttpGet("ListHeldItems")]
        public async Task<ActionResult<IEnumerable<HeldItemDTO>>> ListHeldItems()
        {
            var heldItemDTOs = await _heldItemService.ListHeldItems();
            return Ok(heldItemDTOs);
        }

        [HttpGet("FindHeldItem/{id}")]
        public async Task<ActionResult<HeldItemDTO>> FindHeldItem(int id)
        {
            var heldItemDTO = await _heldItemService.FindHeldItem(id);
            if (heldItemDTO == null)
            {
                return NotFound();
            }
            return Ok(heldItemDTO);
        }

        [HttpPost("CreateHeldItem")]
        public async Task<ActionResult<HeldItemDTO>> CreateHeldItem(HeldItemDTO heldItemDTO)
        {
            if (heldItemDTO == null)
            {
                return BadRequest();
            }

            var createdHeldItem = await _heldItemService.CreateHeldItem(heldItemDTO);
            return CreatedAtAction(nameof(FindHeldItem), new { id = createdHeldItem.HeldItemId }, createdHeldItem);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateHeldItem(int id, HeldItemDTO heldItemDTO)
        {
            if (id != heldItemDTO.HeldItemId)
            {
                return BadRequest();
            }

            var result = await _heldItemService.UpdateHeldItem(id, heldItemDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteHeldItem(int id)
        {
            var result = await _heldItemService.DeleteHeldItem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
