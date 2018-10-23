using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SnelStart.B2BClient.Web.Models;
using SnelStart.B2BClient.Web.Utilities;

namespace SnelStart.B2BClient.Web.Controllers
{
    public class VerkoopfactuurController : Controller
    {
        private readonly AppSettings settings;

        public VerkoopfactuurController(IOptions<AppSettings> settings) {
            this.settings = settings.Value;
        }

        public IActionResult Index()
        {
            List<VerkoopfactuurModel> verkoopOrders = this.GetVerkoopfacturenAsync().Result;

            return View(verkoopOrders);
        }

        public IActionResult Details(string id)
        {
            var verkoopOrder = this.GetVerkoopfactuurAsync(id).Result;

            return View(verkoopOrder);
        }

        private async Task<VerkoopfactuurModel> GetVerkoopfactuurAsync(string id)
        {
            var client = B2BApiUtility.GetB2BApiClient(settings);

            var uri = $"{settings.B2BApiBaseAddress}/verkoopfacturen/{id}";
            var response = await client.GetAsync(uri);
            var responseContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<VerkoopfactuurModel>(responseContentString);
        }

        private async Task<List<VerkoopfactuurModel>> GetVerkoopfacturenAsync()
        {
            var client = B2BApiUtility.GetB2BApiClient(settings);

            var uri = $"{settings.B2BApiBaseAddress}/verkoopfacturen";
            var response = await client.GetAsync(uri);
            var responseContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<VerkoopfactuurModel>>(responseContentString);
        }


    }
}