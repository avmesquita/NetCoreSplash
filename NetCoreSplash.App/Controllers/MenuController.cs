using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreSplash.App.Models;
using Newtonsoft.Json;

namespace NetCoreSplash.App.Controllers
{
    public class MenuController : Controller
    {
        private readonly IConfiguration _configuration;
        public MenuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string APImenta { get { return _configuration["APImenta"]; } }

        public async Task<IActionResult> Index()
        {
            List<MenuViewModel> listaReservas = new List<MenuViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(this.APImenta+"/Menu"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaReservas = JsonConvert.DeserializeObject<List<MenuViewModel>>(apiResponse);
                }
            }
            return View(listaReservas);
        }
    }
}