using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Messeger.MVC.NetCORE.UI.Helper;
using System.Text;
using Messeger.Entity;
using Messeger.MVC.NetCORE.UI.Models.Api;
using Messeger.MVC.NetCORE.UI.FilterAttribute;

namespace Messeger.MVC.NetCORE.UI.Controllers
{
    [ServiceFilter(typeof(MemberAttribute))]
    public class MessageController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Send(string text, int MessageID)
        {
            SendMessage sendMessage = new SendMessage() { MemberID = HttpContext.Session.GetObjectFromJson<Members>("MemberLog").ID, MessageID = MessageID, Text = text };

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sendMessage), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44309/api/Message", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bool ReturnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Models.Api.Message message)
        {

            message.CreaterID = HttpContext.Session.GetObjectFromJson<Member>("MemberLog").ID;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44309/api/Message/Create", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bool ReturnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Invite(int MessageID, string Tagname)
        {
            InviteReturnData ReturnValue = null;
            Models.Api.Invite inviteData = new Models.Api.Invite() { MessageID = MessageID, Tagname = Tagname };
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(inviteData), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44309/api/Message/Invite", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ReturnValue = JsonConvert.DeserializeObject<InviteReturnData>(apiResponse);
                }
            }
            return Json(ReturnValue);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int MessageID, int CreaterID)
        {
    
            if (CreaterID == HttpContext.Session.GetObjectFromJson<Member>("MemberLog").ID)
            {
                Delete postValue = new Delete() { MemberID = CreaterID, MessageID = MessageID };
                bool ReturnValue = false;
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(postValue), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44309/api/Message/Delete", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ReturnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
                    }
                }
                if (ReturnValue)
                    return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int MessageID, int CreaterID)
        {           
                Delete postValue = new Delete() { MemberID = CreaterID, MessageID = MessageID };
                bool ReturnValue = false;
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(postValue), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44309/api/Message/Leave", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ReturnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
                    }
                }
                if (ReturnValue)
                    return Json(true);           
            return Json(false);
        }


    }
}