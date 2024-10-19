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
    public class BattleItemAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BattleItemAPIController(ApplicationDbContext context)
        {
            _context = context;
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
        [HttpGet(template:"ListBattleItems")]
        public async Task<ActionResult<IEnumerable<BattleItemDTO>>> ListBattleItems()
        {
            var battleItems = await _context.BattleItems.ToListAsync();

            var battleItemDTOs = battleItems.Select(bi => new BattleItemDTO
            {
                BattleItemId = bi.BattleItemId,
                BattleItemImgLink = bi.BattleItemImgLink,
                BattleItemName = bi.BattleItemName,
                BattleItemHP = bi.BattleItemHP,
                BattleItemAttack = bi.BattleItemAttack,
                BattleItemDefense = bi.BattleItemDefense,
                BattleItemSpAttack = bi.BattleItemSpAttack,
                BattleItemSpDefense = bi.BattleItemSpDefense,
                BattleItemCritRate = bi.BattleItemCritRate,
                BattleItemCDR = bi.BattleItemCDR,
                BattleItemLifesteal = bi.BattleItemLifesteal,
                BattleItemAttackSpeed = bi.BattleItemAttackSpeed,
                BattleItemMoveSpeed = bi.BattleItemMoveSpeed
            }).ToList();

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
            var battleItem = await _context.BattleItems.FindAsync(id);

            if (battleItem == null)
            {
                return NotFound();
            }

            var battleItemDTO = new BattleItemDTO
            {
                BattleItemId = battleItem.BattleItemId,
                BattleItemImgLink = battleItem.BattleItemImgLink,
                BattleItemName = battleItem.BattleItemName,
                BattleItemHP = battleItem.BattleItemHP,
                BattleItemAttack = battleItem.BattleItemAttack,
                BattleItemDefense = battleItem.BattleItemDefense,
                BattleItemSpAttack = battleItem.BattleItemSpAttack,
                BattleItemSpDefense = battleItem.BattleItemSpDefense,
                BattleItemCritRate = battleItem.BattleItemCritRate,
                BattleItemCDR = battleItem.BattleItemCDR,
                BattleItemLifesteal = battleItem.BattleItemLifesteal,
                BattleItemAttackSpeed = battleItem.BattleItemAttackSpeed,
                BattleItemMoveSpeed = battleItem.BattleItemMoveSpeed
            };

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

            var battleItem = new BattleItem
            {
                BattleItemImgLink = battleItemDTO.BattleItemImgLink,
                BattleItemName = battleItemDTO.BattleItemName,
                BattleItemHP = battleItemDTO.BattleItemHP,
                BattleItemAttack = battleItemDTO.BattleItemAttack,
                BattleItemDefense = battleItemDTO.BattleItemDefense,
                BattleItemSpAttack = battleItemDTO.BattleItemSpAttack,
                BattleItemSpDefense = battleItemDTO.BattleItemSpDefense,
                BattleItemCritRate = battleItemDTO.BattleItemCritRate,
                BattleItemCDR = battleItemDTO.BattleItemCDR,
                BattleItemLifesteal = battleItemDTO.BattleItemLifesteal,
                BattleItemAttackSpeed = battleItemDTO.BattleItemAttackSpeed,
                BattleItemMoveSpeed = battleItemDTO.BattleItemMoveSpeed
            };

            _context.BattleItems.Add(battleItem);
            await _context.SaveChangesAsync();

            battleItemDTO.BattleItemId = battleItem.BattleItemId;

            return CreatedAtAction(nameof(FindBattleItem), new { id = battleItem.BattleItemId }, battleItemDTO);
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

            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null)
            {
                return NotFound();
            }

            battleItem.BattleItemImgLink = battleItemDTO.BattleItemImgLink;
            battleItem.BattleItemName = battleItemDTO.BattleItemName;
            battleItem.BattleItemHP = battleItemDTO.BattleItemHP;
            battleItem.BattleItemAttack = battleItemDTO.BattleItemAttack;
            battleItem.BattleItemDefense = battleItemDTO.BattleItemDefense;
            battleItem.BattleItemSpAttack = battleItemDTO.BattleItemSpAttack;
            battleItem.BattleItemSpDefense = battleItemDTO.BattleItemSpDefense;
            battleItem.BattleItemCritRate = battleItemDTO.BattleItemCritRate;
            battleItem.BattleItemCDR = battleItemDTO.BattleItemCDR;
            battleItem.BattleItemLifesteal = battleItemDTO.BattleItemLifesteal;
            battleItem.BattleItemAttackSpeed = battleItemDTO.BattleItemAttackSpeed;
            battleItem.BattleItemMoveSpeed = battleItemDTO.BattleItemMoveSpeed;

            _context.Entry(battleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleItemExists(id))
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
            var battleItem = await _context.BattleItems.FindAsync(id);

            if (battleItem == null)
            {
                return NotFound();
            }

            _context.BattleItems.Remove(battleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BattleItemExists(int id)
        {
            return _context.BattleItems.Any(e => e.BattleItemId == id);
        }
    }
}
