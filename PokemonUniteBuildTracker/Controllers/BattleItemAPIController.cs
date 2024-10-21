using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleItemAPIController : ControllerBase
    {
        private readonly IBattleItemService _battleItemService;

        public BattleItemAPIController(IBattleItemService battleItemService)
        {
            _battleItemService = battleItemService;
        }

        /// <summary>
        /// Returns a list of all battle items in the database.
        /// </summary>
        /// <returns>
        /// A list of BattleItemDTOs.
        /// </returns>
        /// <example>
        /// GET api/battleitemapi/listbattleitems
        /// </example>
        [HttpGet("ListBattleItems")]
        public async Task<ActionResult<IEnumerable<BattleItemDTO>>> ListBattleItems()
        {
            var battleItemDTOs = await _battleItemService.ListBattleItems();
            return Ok(battleItemDTOs);
        }

        /// <summary>
        /// Finds the battle item by its ID and returns the battle item data.
        /// </summary>
        /// <param name="id">Primary key for battle item in the database.</param>
        /// <returns>
        /// A BattleItemDTO.
        /// </returns>
        /// <example>
        /// GET api/battleitemapi/findbattleitem/3
        /// </example>
        [HttpGet("FindBattleItem/{id}")]
        public async Task<ActionResult<BattleItemDTO>> FindBattleItem(int id)
        {
            var battleItemDTO = await _battleItemService.FindBattleItem(id);
            if (battleItemDTO == null)
            {
                return NotFound();
            }
            return Ok(battleItemDTO);
        }

        /// <summary>
        /// Creates a new battle item.
        /// </summary>
        /// <param name="battleItemDTO">Information to create a new battle item.</param>
        /// <returns>
        /// The created BattleItemDTO.
        /// </returns>
        /// <example>
        /// POST api/battleitemapi/createbattleitem
        /// </example>
        [HttpPost("CreateBattleItem")]
        public async Task<ActionResult<BattleItemDTO>> CreateBattleItem(BattleItemDTO battleItemDTO)
        {
            if (battleItemDTO == null)
            {
                return BadRequest();
            }

            var createdBattleItem = await _battleItemService.CreateBattleItem(battleItemDTO);
            return CreatedAtAction(nameof(FindBattleItem), new { id = createdBattleItem.BattleItemId }, createdBattleItem);
        }

        /// <summary>
        /// Updates a battle item.
        /// </summary>
        /// <param name="id">The ID of the battle item to update.</param>
        /// <param name="battleItemDTO">Updated battle item information.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// PUT api/battleitemapi/update/5
        /// </example>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBattleItem(int id, BattleItemDTO battleItemDTO)
        {
            if (id != battleItemDTO.BattleItemId)
            {
                return BadRequest();
            }

            var result = await _battleItemService.UpdateBattleItem(id, battleItemDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes the battle item from the database.
        /// </summary>
        /// <param name="id">The ID of the battle item to be deleted.</param>
        /// <returns>
        /// No content.
        /// </returns>
        /// <example>
        /// DELETE api/battleitemapi/delete/5
        /// </example>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBattleItem(int id)
        {
            var result = await _battleItemService.DeleteBattleItem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
