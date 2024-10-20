// Controllers/BattleItemController.cs
using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Models;
using PokemonUniteBuildTracker.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonUniteBuildTracker.Controllers
{
    public class BattleItemController : BaseApiController
    {
        public BattleItemController() : base()
        {
        }

        public async Task<IActionResult> Index()
        {
            var battleItems = await _httpClient.GetFromJsonAsync<IEnumerable<BattleItemViewModel>>("api/battleitemapi/listbattleitems");
            return View(battleItems);
        }

        public async Task<IActionResult> Details(int id)
        {
            var battleItem = await _httpClient.GetFromJsonAsync<BattleItemViewModel>($"api/battleitemapi/findbattleitem/{id}");
            if (battleItem != null)
            {
                return View(battleItem);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BattleItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BattleItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var battleItemDto = new BattleItemDTO
                {
                    // Map properties from model to DTO
                    BattleItemImgLink = model.BattleItemImgLink,
                    BattleItemName = model.BattleItemName,
                    BattleItemHP = model.BattleItemHP,
                    BattleItemAttack = model.BattleItemAttack,
                    BattleItemDefense = model.BattleItemDefense,
                    BattleItemSpAttack = model.BattleItemSpAttack,
                    BattleItemSpDefense = model.BattleItemSpDefense,
                    BattleItemCritRate = model.BattleItemCritRate,
                    BattleItemCDR = model.BattleItemCDR,
                    BattleItemLifesteal = model.BattleItemLifesteal,
                    BattleItemAttackSpeed = model.BattleItemAttackSpeed,
                    BattleItemMoveSpeed = model.BattleItemMoveSpeed
                };

                var response = await _httpClient.PostAsJsonAsync("api/battleitemapi/createbattleitem", battleItemDto);
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
            var battleItem = await _httpClient.GetFromJsonAsync<BattleItemViewModel>($"api/battleitemapi/findbattleitem/{id}");
            if (battleItem != null)
            {
                return View(battleItem);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BattleItemViewModel model)
        {
            if (id != model.BattleItemId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var battleItemDto = new BattleItemDTO
                {
                    BattleItemId = model.BattleItemId,
                    BattleItemImgLink = model.BattleItemImgLink,
                    BattleItemName = model.BattleItemName,
                    BattleItemHP = model.BattleItemHP,
                    BattleItemAttack = model.BattleItemAttack,
                    BattleItemDefense = model.BattleItemDefense,
                    BattleItemSpAttack = model.BattleItemSpAttack,
                    BattleItemSpDefense = model.BattleItemSpDefense,
                    BattleItemCritRate = model.BattleItemCritRate,
                    BattleItemCDR = model.BattleItemCDR,
                    BattleItemLifesteal = model.BattleItemLifesteal,
                    BattleItemAttackSpeed = model.BattleItemAttackSpeed,
                    BattleItemMoveSpeed = model.BattleItemMoveSpeed
                };

                var response = await _httpClient.PutAsJsonAsync($"api/battleitemapi/update/{id}", battleItemDto);
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
            var battleItem = await _httpClient.GetFromJsonAsync<BattleItemViewModel>($"api/battleitemapi/findbattleitem/{id}");
            if (battleItem != null)
            {
                return View(battleItem);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/battleitemapi/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
