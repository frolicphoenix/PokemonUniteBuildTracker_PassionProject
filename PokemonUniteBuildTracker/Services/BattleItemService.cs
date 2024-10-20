// Services/BattleItemService.cs
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

        public async Task<IEnumerable<BattleItemDTO>> ListBattleItems()
        {
            var battleItems = await _context.BattleItems.ToListAsync();
            return battleItems.Select(bi => new BattleItemDTO
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
            });
        }

        public async Task<BattleItemDTO> FindBattleItem(int id)
        {
            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null) return null;

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

        public async Task<BattleItemDTO> CreateBattleItem(BattleItemDTO battleItemDTO)
        {
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
            return battleItemDTO;
        }

        public async Task<bool> UpdateBattleItem(int id, BattleItemDTO battleItemDTO)
        {
            if (id != battleItemDTO.BattleItemId) return false;

            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null) return false;

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
                if (!BattleItemExists(id)) return false;
                else throw;
            }
        }

        public async Task<bool> DeleteBattleItem(int id)
        {
            var battleItem = await _context.BattleItems.FindAsync(id);
            if (battleItem == null) return false;

            _context.BattleItems.Remove(battleItem);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool BattleItemExists(int id)
        {
            return _context.BattleItems.Any(e => e.BattleItemId == id);
        }
    }
}
