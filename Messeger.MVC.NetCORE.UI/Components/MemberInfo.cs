using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Helper;
using Messeger.Entity;

namespace Messeger.MVC.NetCORE.UI.Components
{
    public class MemberInfo : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data =  HttpContext.Session.GetObjectFromJson<Member>("MemberLog");
            return View(data);
        }
    }
}
