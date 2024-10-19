using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonUniteBuildTracker.Data;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Services
{
    public class HeldItemService : IHeldItemService
    {
        private readonly ApplicationDbContext _context;

        public HeldItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HeldItemDTO>> GetAllHeldItemsAsync()
        {
            var heldItems = await _context.HeldItems.ToListAsync();
            var heldItemDTOs = heldItems.Select(hi => MapToDTO(hi)).ToList();
            return heldItemDTOs;
        }

        public async Task<HeldItemDTO> GetHeldItemByIdAsync(int id)
        {
            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null)
                return null;

            return MapToDTO(heldItem);
        }

        public async Task<HeldItemDTO> CreateHeldItemAsync(HeldItemDTO heldItemDTO)
        {
            var heldItem = MapToEntity(heldItemDTO);
            _context.HeldItems.Add(heldItem);
            await _context.SaveChangesAsync();
            heldItemDTO.HeldItemId = heldItem.HeldItemId;
            return heldItemDTO;
        }

        public async Task<bool> UpdateHeldItemAsync(int id, HeldItemDTO heldItemDTO)
        {
            if (id != heldItemDTO.HeldItemId)
                return false;

            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null)
                return false;

            // Update properties
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
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeldItemExists(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteHeldItemAsync(int id)
        {
            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null)
                return false;

            _context.HeldItems.Remove(heldItem);
            await _context.SaveChangesAsync();
            return true;
        }

        // Helper methods

        private bool HeldItemExists(int id)
        {
            return _context.HeldItems.Any(e => e.HeldItemId == id);
        }

        private HeldItemDTO MapToDTO(HeldItem heldItem)
        {
            return new HeldItemDTO
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
        }

        private HeldItem MapToEntity(HeldItemDTO dto)
        {
            return new HeldItem
            {
                HeldItemImgLink = dto.HeldItemImgLink,
                HeldItemName = dto.HeldItemName,
                HeldItemHP = dto.HeldItemHP,
                HeldItemAttack = dto.HeldItemAttack,
                HeldItemDefense = dto.HeldItemDefense,
                HeldItemSpAttack = dto.HeldItemSpAttack,
                HeldItemSpDefense = dto.HeldItemSpDefense,
                HeldItemCritRate = dto.HeldItemCritRate,
                HeldItemCDR = dto.HeldItemCDR,
                HeldItemLifesteal = dto.HeldItemLifesteal,
                HeldItemAttackSpeed = dto.HeldItemAttackSpeed,
                HeldItemMoveSpeed = dto.HeldItemMoveSpeed
            };
        }
    }
}
