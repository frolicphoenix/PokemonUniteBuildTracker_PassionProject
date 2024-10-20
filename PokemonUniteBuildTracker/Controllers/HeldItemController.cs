// Controllers/HeldItemController.cs
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

        public async Task<IActionResult> Index()
        {
            var heldItems = await _httpClient.GetFromJsonAsync<IEnumerable<HeldItemViewModel>>("api/helditemapi/listhelditems");
            return View(heldItems);
        }

        public async Task<IActionResult> Details(int id)
        {
            var heldItem = await _httpClient.GetFromJsonAsync<HeldItemViewModel>($"api/helditemapi/findhelditem/{id}");
            if (heldItem != null)
            {
                return View(heldItem);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new HeldItemViewModel());
        }

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
