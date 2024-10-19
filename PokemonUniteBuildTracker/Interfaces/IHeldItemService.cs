using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    public interface IHeldItemService
    {
        Task<IEnumerable<HeldItemDTO>> GetAllHeldItemsAsync();
        Task<HeldItemDTO> GetHeldItemByIdAsync(int id);
        Task<HeldItemDTO> CreateHeldItemAsync(HeldItemDTO heldItemDTO);
        Task<bool> UpdateHeldItemAsync(int id, HeldItemDTO heldItemDTO);
        Task<bool> DeleteHeldItemAsync(int id);
    }
}
