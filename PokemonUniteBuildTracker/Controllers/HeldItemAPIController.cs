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
    public class HeldItemAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeldItemAPIController(ApplicationDbContext context)
        {
            _context = context;
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
            var heldItems = await _context.HeldItems.ToListAsync();

            var heldItemDTOs = heldItems.Select(hi => new HeldItemDTO
            {
                HeldItemId = hi.HeldItemId,
                HeldItemImgLink = hi.HeldItemImgLink,
                HeldItemName = hi.HeldItemName,
                HeldItemHP = hi.HeldItemHP,
                HeldItemAttack = hi.HeldItemAttack,
                HeldItemDefense = hi.HeldItemDefense,
                HeldItemSpAttack = hi.HeldItemSpAttack,
                HeldItemSpDefense = hi.HeldItemSpDefense,
                HeldItemCritRate = hi.HeldItemCritRate,
                HeldItemCDR = hi.HeldItemCDR,
                HeldItemLifesteal = hi.HeldItemLifesteal,
                HeldItemAttackSpeed = hi.HeldItemAttackSpeed,
                HeldItemMoveSpeed = hi.HeldItemMoveSpeed
            }).ToList();

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
            var heldItem = await _context.HeldItems.FindAsync(id);

            if (heldItem == null)
            {
                return NotFound();
            }

            var heldItemDTO = new HeldItemDTO
            {
                HeldItemId = heldItem.HeldItemId,
                HeldItemImgLink = heldItem.HeldItemImgLink,
                HeldItemName = heldItem.HeldItemName,
                HeldItemHP = heldItem.HeldItemHP,
                HeldItemAttack = heldItem.HeldItemAttack,
                HeldItemDefense = heldItem.HeldItemDefense,
                HeldItemSpAttack = heldItem.HeldItemSpAttack,
                HeldItemSpDefense = heldItem.HeldItemSpDefense,
                HeldItemCritRate = heldItem.HeldItemCritRate,
                HeldItemCDR = heldItem.HeldItemCDR,
                HeldItemLifesteal = heldItem.HeldItemLifesteal,
                HeldItemAttackSpeed = heldItem.HeldItemAttackSpeed,
                HeldItemMoveSpeed = heldItem.HeldItemMoveSpeed
            };

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

            var heldItem = new HeldItem
            {
                HeldItemImgLink = heldItemDTO.HeldItemImgLink,
                HeldItemName = heldItemDTO.HeldItemName,
                HeldItemHP = heldItemDTO.HeldItemHP,
                HeldItemAttack = heldItemDTO.HeldItemAttack,
                HeldItemDefense = heldItemDTO.HeldItemDefense,
                HeldItemSpAttack = heldItemDTO.HeldItemSpAttack,
                HeldItemSpDefense = heldItemDTO.HeldItemSpDefense,
                HeldItemCritRate = heldItemDTO.HeldItemCritRate,
                HeldItemCDR = heldItemDTO.HeldItemCDR,
                HeldItemLifesteal = heldItemDTO.HeldItemLifesteal,
                HeldItemAttackSpeed = heldItemDTO.HeldItemAttackSpeed,
                HeldItemMoveSpeed = heldItemDTO.HeldItemMoveSpeed
            };

            _context.HeldItems.Add(heldItem);
            await _context.SaveChangesAsync();

            heldItemDTO.HeldItemId = heldItem.HeldItemId;

            return CreatedAtAction(nameof(FindHeldItem), new { id = heldItem.HeldItemId }, heldItemDTO);
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

            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null)
            {
                return NotFound();
            }

            heldItem.HeldItemImgLink = heldItemDTO.HeldItemImgLink;
            heldItem.HeldItemName = heldItemDTO.HeldItemName;
            heldItem.HeldItemHP = heldItemDTO.HeldItemHP;
            heldItem.HeldItemAttack = heldItemDTO.HeldItemAttack;
            heldItem.HeldItemDefense = heldItemDTO.HeldItemDefense;
            heldItem.HeldItemSpAttack = heldItemDTO.HeldItemSpAttack;
            heldItem.HeldItemSpDefense = heldItemDTO.HeldItemSpDefense;
            heldItem.HeldItemCritRate = heldItemDTO.HeldItemCritRate;
            heldItem.HeldItemCDR = heldItemDTO.HeldItemCDR;
            heldItem.HeldItemLifesteal = heldItemDTO.HeldItemLifesteal;
            heldItem.HeldItemAttackSpeed = heldItemDTO.HeldItemAttackSpeed;
            heldItem.HeldItemMoveSpeed = heldItemDTO.HeldItemMoveSpeed;

            _context.Entry(heldItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeldItemExists(id))
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
            var heldItem = await _context.HeldItems.FindAsync(id);

            if (heldItem == null)
            {
                return NotFound();
            }

            _context.HeldItems.Remove(heldItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeldItemExists(int id)
        {
            return _context.HeldItems.Any(e => e.HeldItemId == id);
        }
    }
}
