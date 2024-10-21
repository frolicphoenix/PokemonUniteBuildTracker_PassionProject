using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonUniteBuildTracker.Models;

namespace PokemonUniteBuildTracker.Interfaces
{
    //Defines the contract for Held Item-related operations.
    public interface IHeldItemService
    {
        Task<IEnumerable<HeldItemDTO>> ListHeldItems();
        Task<HeldItemDTO> FindHeldItem(int id);
        Task<HeldItemDTO> CreateHeldItem(HeldItemDTO heldItemDTO);
        Task<bool> UpdateHeldItem(int id, HeldItemDTO heldItemDTO);
        Task<bool> DeleteHeldItem(int id);
    }
}
