using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messeger.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Messeger.MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        public class PostLoginMember
        {
            public string Username { get; set; }
            public string Password { get; set; }

        }

        public  IActionResult Index()
        {
            return  View();
        }
        
        public async Task<IActionResult> LoginMember(PostLoginMember loginPost)
        {
            Member IsLoginMember;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginPost), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44309/api/Member/Login", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    IsLoginMember = JsonConvert.DeserializeObject<Member>(apiResponse);
                }
            }
            if (IsLoginMember != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}