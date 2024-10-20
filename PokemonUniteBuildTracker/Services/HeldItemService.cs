// Services/HeldItemService.cs
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

        public async Task<IEnumerable<HeldItemDTO>> ListHeldItems()
        {
            var heldItems = await _context.HeldItems.ToListAsync();
            return heldItems.Select(hi => new HeldItemDTO
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
            });
        }

        public async Task<HeldItemDTO> FindHeldItem(int id)
        {
            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null) return null;

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

        public async Task<HeldItemDTO> CreateHeldItem(HeldItemDTO heldItemDTO)
        {
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
            return heldItemDTO;
        }

        public async Task<bool> UpdateHeldItem(int id, HeldItemDTO heldItemDTO)
        {
            if (id != heldItemDTO.HeldItemId) return false;

            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null) return false;

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
                if (!HeldItemExists(id)) return false;
                else throw;
            }
        }

        public async Task<bool> DeleteHeldItem(int id)
        {
            var heldItem = await _context.HeldItems.FindAsync(id);
            if (heldItem == null) return false;

            _context.HeldItems.Remove(heldItem);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool HeldItemExists(int id)
        {
            return _context.HeldItems.Any(e => e.HeldItemId == id);
        }
    }
}
