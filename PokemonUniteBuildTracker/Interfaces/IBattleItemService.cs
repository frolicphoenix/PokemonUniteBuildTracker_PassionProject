using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    public interface IBattleItemService
    {
        Task<IEnumerable<BattleItemDTO>> GetAllBattleItemsAsync();
        Task<BattleItemDTO> GetBattleItemByIdAsync(int id);
        Task<BattleItemDTO> CreateBattleItemAsync(BattleItemDTO battleItemDTO);
        Task<bool> UpdateBattleItemAsync(int id, BattleItemDTO battleItemDTO);
        Task<bool> DeleteBattleItemAsync(int id);
    }
}
