using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Messeger.MVC.NetCORE.UI.Validations
{
    public class CustomValidationController : Controller
    {

        //[HttpPost]
        //public async Task<IActionResult> Email(string Email)
        //{
        //    bool Result = false;
        //    using (var httpClient = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(Username), Encoding.UTF8, "application/json");
        //        using (var response = await httpClient.PostAsync("https://localhost:44309/api/Member", content))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            Result = JsonConvert.DeserializeObject<bool>(apiResponse);
        //        }
        //    }
        //    return Json(Result);
        //}
        [AcceptVerbs("Get", "Post")]
        public IActionResult Email(string Email)
        {
            return Json(true);
        }
        public async Task<bool> Tagname(string tagName)
        {
            return true;
        }
    }
}