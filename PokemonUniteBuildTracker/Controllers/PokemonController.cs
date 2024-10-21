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

        /// <summary>
        /// Displays the list of all Pokémon.
        /// </summary>
        /// <returns>The view displaying the list of Pokémon.</returns>
        public async Task<IActionResult> Index()
        {
            var pokemons = await _httpClient.GetFromJsonAsync<IEnumerable<PokemonViewModel>>("api/pokemonapi/listpokemons");
            return View(pokemons);
        }

        /// <summary>
        /// Displays the details of a specific Pokémon.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon.</param>
        /// <returns>The view displaying the Pokémon details if found; otherwise, a NotFound result.</returns>
        public async Task<IActionResult> Details(int id)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonViewModel>($"api/pokemonapi/findpokemon/{id}");
            if (pokemon != null)
            {
                return View(pokemon);
            }
            return NotFound();
        }

        /// <summary>
        /// Displays the form for creating a new Pokémon.
        /// </summary>
        /// <returns>The view displaying the create Pokémon form.</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new PokemonViewModel
            {
                /*AvailableHeldItems = await GetHeldItems(),
                AvailableBattleItems = await GetBattleItems()*/
            };
            return View(model);
        }

        /// <summary>
        /// Handles the submission of the create Pokémon form.
        /// </summary>
        /// <param name="model">The view model containing Pokémon data.</param>
        /// <returns>
        /// Redirects to the Index view if creation is successful; otherwise, redisplays the form with errors.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pokemonDto = new PokemonDTO
                {
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
                };

                try
                {
                    var response = await _httpClient.PostAsJsonAsync("api/pokemonapi/createpokemon", pokemonDto);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"API Error: {errorContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Network Error: {ex.Message}");
                }
            }

           /* model.AvailableHeldItems = await GetHeldItems();
            model.AvailableBattleItems = await GetBattleItems();*/
            return View(model);
        }

        /// <summary>
        /// Displays the form for editing an existing Pokémon.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to edit.</param>
        /// <returns>The view displaying the edit Pokémon form if found; otherwise, a NotFound result.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonViewModel>($"api/pokemonapi/findpokemon/{id}");
            if (pokemon != null)
            {
                /*pokemon.AvailableHeldItems = await GetHeldItems();
                pokemon.AvailableBattleItems = await GetBattleItems();*/
                return View(pokemon);
            }
            return NotFound();
        }

        /// <summary>
        /// Handles the submission of the edit Pokémon form.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to update.</param>
        /// <param name="model">The view model containing updated Pokémon data.</param>
        /// <returns>
        /// Redirects to the Index view if update is successful; otherwise, redisplays the form with errors.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PokemonViewModel model)
        {
            if (id != model.PokemonId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
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
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"API Error: {errorContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Network Error: {ex.Message}");
                }
            }

            /*model.AvailableHeldItems = await GetHeldItems();
            model.AvailableBattleItems = await GetBattleItems();*/
            return View(model);
        }

        /// <summary>
        /// Displays the confirmation view for deleting a Pokémon.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to delete.</param>
        /// <returns>The view displaying the delete confirmation if found; otherwise, a NotFound result.</returns>
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

        /// <summary>
        /// Handles the deletion of a Pokémon after confirmation.
        /// </summary>
        /// <param name="id">The unique identifier of the Pokémon to delete.</param>
        /// <returns>
        /// Redirects to the Index view if deletion is successful; otherwise, returns a BadRequest result.
        /// </returns>
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

        /// <summary>
        /// Retrieves the list of available Held Items.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="HeldItemViewModel"/>.</returns>
        private async Task<List<HeldItemViewModel>> GetHeldItems()
        {
            var heldItems = await _httpClient.GetFromJsonAsync<List<HeldItemViewModel>>("api/helditemapi/listhelditems");
            return heldItems ?? new List<HeldItemViewModel>();
        }

        /// <summary>
        /// Retrieves the list of available Battle Items.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="BattleItemViewModel"/>.</returns>
        private async Task<List<BattleItemViewModel>> GetBattleItems()
        {
            var battleItems = await _httpClient.GetFromJsonAsync<List<BattleItemViewModel>>("api/battleitemapi/listbattleitems");
            return battleItems ?? new List<BattleItemViewModel>();
        }

        /// <summary>
        /// Displays the build creation form.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the "IActionResult" rendering the build creation view.
        /// </returns>
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

        /// <summary>
        /// Handles the submission of the build creation form.
        /// </summary>
        /// <param name="model">The "BuildViewModel" containing build data.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an "IActionResult" rendering the build creation view with calculated stats.
        /// </returns>
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

        /// <summary>
        /// Calculates the total stats for a build based on selected Pokémon, Held Items, and Battle Item.
        /// </summary>
        /// <param name="model">The "BuildViewModel"containing selected items and Pokémon.</param>
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
