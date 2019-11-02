using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messeger.MVC.NetCORE.UI.Helper;
using Messeger.Entity;
using Messeger.MVC.NetCORE.UI.Models.Api;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Messeger.MVC.NetCORE.UI.Controllers
{
    public class MemberController : Controller
    {

        [HttpGet]
        public IActionResult Update()
        {
            var data = HttpContext.Session.GetObjectFromJson<Member>("MemberLog");
            return View(new Register() { Email = data.Email, Name = data.Name, Password = data.Password, Phone = data.Phone, Surname = data.Surname, TagName = data.TagName, Username = data.Username ,ID=data.ID});
        }
        [HttpPut]
        public IActionResult PutUpdateMember(Register member)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Register member)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,"application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44309/api/Member/Update", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bool ReturnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
                    }
                } 
            }
            return View();
        }
    }
}