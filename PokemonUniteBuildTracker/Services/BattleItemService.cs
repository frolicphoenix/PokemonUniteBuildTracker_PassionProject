using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonUniteBuildTracker.Data;
using PokemonUniteBuildTracker.Interfaces;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Services
{
    public class BattleItemService : IBattleItemService
    {
        private readonly ApplicationDbContext _context;

        public BattleItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BattleItemDTO>> GetAllBattleItemsAsync()
        {
            var battleItems = await _context.BattleItems.ToListAsync();
            var battleItemDTOs = battleItems.Select(bi => MapToDTO(bi)).ToList();
            return battleItemDTOs;
        }

        public async Task<BattleItemDTO> GetBattleItemByIdAsync(int id)
        {
            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null)
                return null;

            return MapToDTO(battleItem);
        }

        public async Task<BattleItemDTO> CreateBattleItemAsync(BattleItemDTO battleItemDTO)
        {
            var battleItem = MapToEntity(battleItemDTO);
            _context.BattleItems.Add(battleItem);
            await _context.SaveChangesAsync();
            battleItemDTO.BattleItemId = battleItem.BattleItemId;
            return battleItemDTO;
        }

        public async Task<bool> UpdateBattleItemAsync(int id, BattleItemDTO battleItemDTO)
        {
            if (id != battleItemDTO.BattleItemId)
                return false;

            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null)
                return false;

            // Update properties
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
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleItemExists(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteBattleItemAsync(int id)
        {
            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null)
                return false;

            _context.BattleItems.Remove(battleItem);
            await _context.SaveChangesAsync();
            return true;
        }

        // Helper methods

        private bool BattleItemExists(int id)
        {
            return _context.BattleItems.Any(e => e.BattleItemId == id);
        }

        private BattleItemDTO MapToDTO(BattleItem battleItem)
        {
            return new BattleItemDTO
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
        }

        private BattleItem MapToEntity(BattleItemDTO dto)
        {
            return new BattleItem
            {
                BattleItemImgLink = dto.BattleItemImgLink,
                BattleItemName = dto.BattleItemName,
                BattleItemHP = dto.BattleItemHP,
                BattleItemAttack = dto.BattleItemAttack,
                BattleItemDefense = dto.BattleItemDefense,
                BattleItemSpAttack = dto.BattleItemSpAttack,
                BattleItemSpDefense = dto.BattleItemSpDefense,
                BattleItemCritRate = dto.BattleItemCritRate,
                BattleItemCDR = dto.BattleItemCDR,
                BattleItemLifesteal = dto.BattleItemLifesteal,
                BattleItemAttackSpeed = dto.BattleItemAttackSpeed,
                BattleItemMoveSpeed = dto.BattleItemMoveSpeed
            };
        }
    }
}
