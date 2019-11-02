using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Messeger.MVC.NetCORE.UI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMember(Register registerMember)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(registerMember), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44309/api/Member/Register", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (JsonConvert.DeserializeObject<bool>(apiResponse))
                            return RedirectToAction("Index", "Login");
                        return View("Index");
                    }
                }
            }
            return View("Index");
        }
    }
}