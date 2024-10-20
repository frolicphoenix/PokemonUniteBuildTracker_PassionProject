using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace PokemonUniteBuildTracker.Controllers
{
    public class BaseApiController : Controller
    {
        protected readonly HttpClient _httpClient;

        public BaseApiController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7014/");
        }
    }
}
