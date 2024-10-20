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

        [HttpGet("ListBattleItems")]
        public async Task<ActionResult<IEnumerable<BattleItemDTO>>> ListBattleItems()
        {
            var battleItemDTOs = await _battleItemService.ListBattleItems();
            return Ok(battleItemDTOs);
        }

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
