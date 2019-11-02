using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messeger.Entity;
using Messeger.MVC.NetCORE.UI.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Messeger.MVC.NetCORE.UI.Helper;

namespace Messeger.MVC.NetCORE.UI.Controllers
{
    public class DetailsController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
           MessagesDetailsMember MessageDetails;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44309/api/Details/"+id))
                {
                    MessageDetails = new MessagesDetailsMember();
                    MessageDetails.dataMessageDetails = new List<Models.Api.MessageDetails>();
                    MessageDetails = new MessagesDetailsMember();
                     string apiResponse = await response.Content.ReadAsStringAsync();
                    MessageDetails = JsonConvert.DeserializeObject<MessagesDetailsMember>(apiResponse);
                }
            }
            MessageDetails.dataMessageMemberDetails.Name = HttpContext.Session.GetObjectFromJson<Member>("MemberLog").Name;
            MessageDetails.dataMessageMemberDetails.Surname = HttpContext.Session.GetObjectFromJson<Member>("MemberLog").Surname;
            return View(MessageDetails);
        }
    }
}