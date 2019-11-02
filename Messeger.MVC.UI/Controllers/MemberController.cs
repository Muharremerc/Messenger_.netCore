using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messeger.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Messeger.MVC.UI.Controllers.LoginController;

namespace Messeger.MVC.UI.Controllers
{
    public class MemberController : Controller
    {       
  
        public ActionResult Index()
        {
            return View();
        }
       
    }
}