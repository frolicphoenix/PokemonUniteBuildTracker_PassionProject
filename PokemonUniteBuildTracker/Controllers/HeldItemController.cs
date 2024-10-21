using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Models;
using PokemonUniteBuildTracker.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonUniteBuildTracker.Controllers
{
    public class HeldItemController : BaseApiController
    {
        public HeldItemController() : base()
        {
        }

        /// <summary>
        /// Displays a list of all Held Items.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "IActionResult" rendering the Held Items list view.
        /// </returns>
        public async Task<IActionResult> Index()
        {
            var heldItems = await _httpClient.GetFromJsonAsync<IEnumerable<HeldItemViewModel>>("api/helditemapi/listhelditems");
            return View(heldItems);
        }

        /// <summary>
        /// Displays the details of a specific Held Item.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "IActionResult" rendering the Held Item details view or a NotFound result.
        /// </returns>
        public async Task<IActionResult> Details(int id)
        {
            var heldItem = await _httpClient.GetFromJsonAsync<HeldItemViewModel>($"api/helditemapi/findhelditem/{id}");
            if (heldItem != null)
            {
                return View(heldItem);
            }
            return NotFound();
        }

        /// <summary>
        /// Displays the Held Item creation form.
        /// </summary>
        /// <returns>
        /// An "IActionResult" rendering the Held Item creation view.
        /// </returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new HeldItemViewModel());
        }

        /// <summary>
        /// Handles the submission of the Held Item creation form.
        /// </summary>
        /// <param name="model">The "HeldItemViewModel" containing Held Item data.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an "IActionResult" redirecting to the index view upon success or redisplaying the form upon failure.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create(HeldItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var heldItemDto = new HeldItemDTO
                {
                    // Map properties from model to DTO
                    HeldItemImgLink = model.HeldItemImgLink,
                    HeldItemName = model.HeldItemName,
                    HeldItemHP = model.HeldItemHP,
                    HeldItemAttack = model.HeldItemAttack,
                    HeldItemDefense = model.HeldItemDefense,
                    HeldItemSpAttack = model.HeldItemSpAttack,
                    HeldItemSpDefense = model.HeldItemSpDefense,
                    HeldItemCritRate = model.HeldItemCritRate,
                    HeldItemCDR = model.HeldItemCDR,
                    HeldItemLifesteal = model.HeldItemLifesteal,
                    HeldItemAttackSpeed = model.HeldItemAttackSpeed,
                    HeldItemMoveSpeed = model.HeldItemMoveSpeed
                };

                var response = await _httpClient.PostAsJsonAsync("api/helditemapi/createhelditem", heldItemDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        /// <summary>
        /// Displays the Held Item editing form for a specific Held Item.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to edit.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "IActionResult" rendering the Held Item editing view or a NotFound result.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var heldItem = await _httpClient.GetFromJsonAsync<HeldItemViewModel>($"api/helditemapi/findhelditem/{id}");
            if (heldItem != null)
            {
                return View(heldItem);
            }
            return NotFound();
        }

        /// <summary>
        /// Handles the submission of the Held Item editing form.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to update.</param>
        /// <param name="model">The "HeldItemViewModel" containing updated Held Item data.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an "IActionResult" redirecting to the index view upon success or redisplaying the form upon failure.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HeldItemViewModel model)
        {
            if (id != model.HeldItemId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var heldItemDto = new HeldItemDTO
                {
                    HeldItemId = model.HeldItemId,
                    HeldItemImgLink = model.HeldItemImgLink,
                    HeldItemName = model.HeldItemName,
                    HeldItemHP = model.HeldItemHP,
                    HeldItemAttack = model.HeldItemAttack,
                    HeldItemDefense = model.HeldItemDefense,
                    HeldItemSpAttack = model.HeldItemSpAttack,
                    HeldItemSpDefense = model.HeldItemSpDefense,
                    HeldItemCritRate = model.HeldItemCritRate,
                    HeldItemCDR = model.HeldItemCDR,
                    HeldItemLifesteal = model.HeldItemLifesteal,
                    HeldItemAttackSpeed = model.HeldItemAttackSpeed,
                    HeldItemMoveSpeed = model.HeldItemMoveSpeed
                };

                var response = await _httpClient.PutAsJsonAsync($"api/helditemapi/update/{id}", heldItemDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        /// <summary>
        /// Displays the Held Item deletion confirmation view.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "IActionResult" rendering the Held Item deletion confirmation view or a NotFound result.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var heldItem = await _httpClient.GetFromJsonAsync<HeldItemViewModel>($"api/helditemapi/findhelditem/{id}");
            if (heldItem != null)
            {
                return View(heldItem);
            }
            return NotFound();
        }

        /// <summary>
        /// Handles the confirmation of Held Item deletion.
        /// </summary>
        /// <param name="id">The unique identifier of the Held Item to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an "IActionResult" redirecting to the index view upon success or returning a BadRequest result upon failure.
        /// </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/helditemapi/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
