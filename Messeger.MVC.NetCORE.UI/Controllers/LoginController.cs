using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messeger.Entity;
using Messeger.MVC.NetCORE.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Messeger.MVC.NetCORE.UI.Helper;
using Microsoft.AspNetCore.Http;
namespace Messeger.MVC.NetCORE.UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginMember(LoginPostModel loginPost)
        {
            Member IsLoginMember;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginPost), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44309/api/Member", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    IsLoginMember = JsonConvert.DeserializeObject<Member>(apiResponse);
                }
            }
            if (IsLoginMember != null)
            {
                var data = JsonConvert.SerializeObject(IsLoginMember);
                HttpContext.Session.SetString("MemberLog", data);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}