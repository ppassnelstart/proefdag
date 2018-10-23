using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SnelStart.B2BClient.Web.Models;
using SnelStart.B2BClient.Web.Utilities;

namespace SnelStart.B2BClient.Web.Controllers
{
    public class VerkooporderController : Controller
    {
        private readonly AppSettings settings;

        public VerkooporderController(IOptions<AppSettings> settings) {
            this.settings = settings.Value;
        }

        public IActionResult Index()
        {
            List<VerkooporderModel> verkoopOrders = this.GetVerkoopordersAsync().Result;

            return View(verkoopOrders);
        }

        public IActionResult Details(string id)
        {
            var verkoopOrder = this.GetVerkooporderAsync(id).Result;

            return View(verkoopOrder);
        }

        public async Task<VerkooporderModel> GetVerkooporderAsync(string id)
        {
            var client = B2BApiUtility.GetB2BApiClient(settings);
            var uri = $"{settings.B2BApiBaseAddress}/verkooporders/{id}";
            var response = await client.GetAsync(uri);
            var responseContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<VerkooporderModel>(responseContentString);
        }

        public async Task<List<VerkooporderModel>> GetVerkoopordersAsync()
        {
            var client = B2BApiUtility.GetB2BApiClient(settings);
            var uri = $"{settings.B2BApiBaseAddress}/verkooporders";
            var response = await client.GetAsync(uri);
            var responseContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<VerkooporderModel>>(responseContentString);
        }
    }
}