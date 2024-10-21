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

        /// <summary>
        /// Returns a list of all held items in the database.
        /// </summary>
        /// <returns>
        /// A list of HeldItemDTOs.
        /// </returns>
        /// <example>
        /// GET api/helditemapi/listhelditems
        /// </example>
        [HttpGet("ListHeldItems")]
        public async Task<ActionResult<IEnumerable<HeldItemDTO>>> ListHeldItems()
        {
            var heldItemDTOs = await _heldItemService.ListHeldItems();
            return Ok(heldItemDTOs);
        }

        /// <summary>
        /// Finds the held item by its ID and returns the held item data.
        /// </summary>
        /// <param name="id">Primary key for held item in the database.</param>
        /// <returns>
        /// A HeldItemDTO.
        /// </returns>
        /// <example>
        /// GET api/helditemapi/findhelditem/3
        /// </example>
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

        /// <summary>
        /// Creates a new held item.
        /// </summary>
        /// <param name="heldItemDTO">Information to create a new held item.</param>
        /// <returns>
        /// The created HeldItemDTO.
        /// </returns>
        /// <example>
        /// POST api/helditemapi/createhelditem
        /// </example>
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

        /// <summary>
        /// Updates a held item.
        /// </summary>
        /// <param name="id">The ID of the held item to update.</param>
        /// <param name="heldItemDTO">Updated held item information.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// PUT api/helditemapi/update/5
        /// </example>
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

        /// <summary>
        /// Deletes the held item from the database.
        /// </summary>
        /// <param name="id">The ID of the held item to be deleted.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// DELETE api/helditemapi/delete/5
        /// </example>
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
