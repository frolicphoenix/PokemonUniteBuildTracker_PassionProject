using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    //Defines the contract for Battle Item-related operations.
    public interface IBattleItemService
    {
        Task<IEnumerable<BattleItemDTO>> ListBattleItems();
        Task<BattleItemDTO> FindBattleItem(int id);
        Task<BattleItemDTO> CreateBattleItem(BattleItemDTO battleItemDTO);
        Task<bool> UpdateBattleItem(int id, BattleItemDTO battleItemDTO);
        Task<bool> DeleteBattleItem(int id);
    }
}
