using Messeger.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Helper;
using System.Text;
using Microsoft.AspNetCore.Http;
using Messeger.MVC.NetCORE.UI.Models.Api;

namespace Messeger.MVC.NetCORE.UI.Components
{
    public class MessageList:ViewComponent
    {
        public MessageList()
        {
                
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MessagesMember> returnMessageList;          
            
            using (var httpClient = new HttpClient())
            {
                var data = HttpContext.Session.GetString("MemberLog");
                var GetMember = JsonConvert.DeserializeObject<Member>(data);
                StringContent content = new StringContent(JsonConvert.SerializeObject(GetMember), Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync("https://localhost:44309/api/Message/"+GetMember.ID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnMessageList = JsonConvert.DeserializeObject<List<MessagesMember>>(apiResponse);
                }
            }
            if (returnMessageList == null)
                return View(null);
            return View(returnMessageList.AsQueryable());
        }
    }
}
