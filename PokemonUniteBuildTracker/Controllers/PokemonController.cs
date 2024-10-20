// Controllers/PokemonController.cs
using Microsoft.AspNetCore.Mvc;
using PokemonUniteBuildTracker.Models;
using PokemonUniteBuildTracker.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonUniteBuildTracker.Controllers
{
    public class PokemonController : BaseApiController
    {
        public PokemonController() : base()
        {
        }

        public async Task<IActionResult> Index()
        {
            var pokemons = await _httpClient.GetFromJsonAsync<IEnumerable<PokemonViewModel>>("api/pokemonapi/listpokemons");
            return View(pokemons);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonViewModel>($"api/pokemonapi/findpokemon/{id}");
            if (pokemon != null)
            {
                return View(pokemon);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new PokemonViewModel
            {
                AvailableHeldItems = await GetHeldItems(),
                AvailableBattleItems = await GetBattleItems()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pokemonDto = new PokemonDTO
                {
                    // Map properties from model to DTO
                    PokemonImgLink = model.PokemonImgLink,
                    PokemonName = model.PokemonName,
                    PokemonRole = model.PokemonRole,
                    PokemonStyle = model.PokemonStyle,
                    PokemonHP = model.PokemonHP,
                    PokemonAttack = model.PokemonAttack,
                    PokemonDefense = model.PokemonDefense,
                    PokemonSpAttack = model.PokemonSpAttack,
                    PokemonSpDefense = model.PokemonSpDefense,
                    PokemonCritRate = model.PokemonCritRate,
                    PokemonCDR = model.PokemonCDR,
                    PokemonLifesteal = model.PokemonLifesteal,
                    PokemonAttackSpeed = model.PokemonAttackSpeed,
                    PokemonMoveSpeed = model.PokemonMoveSpeed,
                    // Add properties for relationships if needed
                };

                var response = await _httpClient.PostAsJsonAsync("api/pokemonapi/createpokemon", pokemonDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            model.AvailableHeldItems = await GetHeldItems();
            model.AvailableBattleItems = await GetBattleItems();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonViewModel>($"api/pokemonapi/findpokemon/{id}");
            if (pokemon != null)
            {
                pokemon.AvailableHeldItems = await GetHeldItems();
                pokemon.AvailableBattleItems = await GetBattleItems();
                return View(pokemon);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PokemonViewModel model)
        {
            if (id != model.PokemonId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var pokemonDto = new PokemonDTO
                {
                    PokemonId = model.PokemonId,
                    PokemonImgLink = model.PokemonImgLink,
                    PokemonName = model.PokemonName,
                    PokemonRole = model.PokemonRole,
                    PokemonStyle = model.PokemonStyle,
                    PokemonHP = model.PokemonHP,
                    PokemonAttack = model.PokemonAttack,
                    PokemonDefense = model.PokemonDefense,
                    PokemonSpAttack = model.PokemonSpAttack,
                    PokemonSpDefense = model.PokemonSpDefense,
                    PokemonCritRate = model.PokemonCritRate,
                    PokemonCDR = model.PokemonCDR,
                    PokemonLifesteal = model.PokemonLifesteal,
                    PokemonAttackSpeed = model.PokemonAttackSpeed,
                    PokemonMoveSpeed = model.PokemonMoveSpeed
                };

                var response = await _httpClient.PutAsJsonAsync($"api/pokemonapi/update/{id}", pokemonDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            model.AvailableHeldItems = await GetHeldItems();
            model.AvailableBattleItems = await GetBattleItems();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonViewModel>($"api/pokemonapi/findpokemon/{id}");
            if (pokemon != null)
            {
                return View(pokemon);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/pokemonapi/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        private async Task<List<HeldItemViewModel>> GetHeldItems()
        {
            var heldItems = await _httpClient.GetFromJsonAsync<List<HeldItemViewModel>>("api/helditemapi/listhelditems");
            return heldItems ?? new List<HeldItemViewModel>();
        }

        private async Task<List<BattleItemViewModel>> GetBattleItems()
        {
            var battleItems = await _httpClient.GetFromJsonAsync<List<BattleItemViewModel>>("api/battleitemapi/listbattleitems");
            return battleItems ?? new List<BattleItemViewModel>();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBuild()
        {
            var model = new BuildViewModel
            {
                AvailablePokemons = await GetPokemons(),
                AvailableHeldItems = await GetHeldItems(),
                AvailableBattleItems = await GetBattleItems()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuild(BuildViewModel model)
        {
            model.AvailablePokemons = await GetPokemons();
            model.AvailableHeldItems = await GetHeldItems();
            model.AvailableBattleItems = await GetBattleItems();

            if (model.SelectedPokemonId == null)
            {
                ModelState.AddModelError("SelectedPokemonId", "Please select a Pokémon.");
                return View(model);
            }

            // Fetch the selected Pokémon
            model.SelectedPokemon = model.AvailablePokemons.FirstOrDefault(p => p.PokemonId == model.SelectedPokemonId);

            if (model.SelectedPokemon == null)
            {
                ModelState.AddModelError("SelectedPokemonId", "Invalid Pokémon selected.");
                return View(model);
            }

            // Calculate the total stats
            CalculateTotalStats(model);

            return View(model);
        }

        private void CalculateTotalStats(BuildViewModel model)
        {
            // Initialize total stats with base stats of the selected Pokémon
            model.TotalHP = model.SelectedPokemon.PokemonHP;
            model.TotalAttack = model.SelectedPokemon.PokemonAttack;
            model.TotalDefense = model.SelectedPokemon.PokemonDefense;
            model.TotalSpAttack = model.SelectedPokemon.PokemonSpAttack;
            model.TotalSpDefense = model.SelectedPokemon.PokemonSpDefense;
            model.TotalCritRate = model.SelectedPokemon.PokemonCritRate;
            model.TotalCDR = model.SelectedPokemon.PokemonCDR;
            model.TotalLifesteal = model.SelectedPokemon.PokemonLifesteal;
            model.TotalAttackSpeed = model.SelectedPokemon.PokemonAttackSpeed;
            model.TotalMoveSpeed = model.SelectedPokemon.PokemonMoveSpeed;

            // Add stats from selected Held Items
            var selectedHeldItems = model.AvailableHeldItems.Where(hi => model.SelectedHeldItemIds.Contains(hi.HeldItemId));
            foreach (var item in selectedHeldItems)
            {
                model.TotalHP += item.HeldItemHP;
                model.TotalAttack += item.HeldItemAttack;
                model.TotalDefense += item.HeldItemDefense;
                model.TotalSpAttack += item.HeldItemSpAttack;
                model.TotalSpDefense += item.HeldItemSpDefense;
                model.TotalCritRate += item.HeldItemCritRate;
                model.TotalCDR += item.HeldItemCDR;
                model.TotalLifesteal += item.HeldItemLifesteal;
                model.TotalAttackSpeed += item.HeldItemAttackSpeed;
                model.TotalMoveSpeed += item.HeldItemMoveSpeed;
            }

            // Add stats from selected Battle Item
            if (model.SelectedBattleItemId.HasValue)
            {
                var battleItem = model.AvailableBattleItems.FirstOrDefault(bi => bi.BattleItemId == model.SelectedBattleItemId.Value);
                if (battleItem != null)
                {
                    model.TotalHP += battleItem.BattleItemHP;
                    model.TotalAttack += battleItem.BattleItemAttack;
                    model.TotalDefense += battleItem.BattleItemDefense;
                    model.TotalSpAttack += battleItem.BattleItemSpAttack;
                    model.TotalSpDefense += battleItem.BattleItemSpDefense;
                    model.TotalCritRate += battleItem.BattleItemCritRate;
                    model.TotalCDR += battleItem.BattleItemCDR;
                    model.TotalLifesteal += battleItem.BattleItemLifesteal;
                    model.TotalAttackSpeed += battleItem.BattleItemAttackSpeed;
                    model.TotalMoveSpeed += battleItem.BattleItemMoveSpeed;
                }
            }
        }

        private async Task<List<PokemonViewModel>> GetPokemons()
        {
            var pokemons = await _httpClient.GetFromJsonAsync<List<PokemonViewModel>>("api/pokemonapi/listpokemons");
            return pokemons ?? new List<PokemonViewModel>();
        }
    }
}
