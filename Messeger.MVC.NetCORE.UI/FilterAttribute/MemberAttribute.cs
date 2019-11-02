using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Helper;
using Messeger.Entity;

namespace Messeger.MVC.NetCORE.UI.FilterAttribute
{
    public class MemberAttribute : IActionFilter
    {


        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tempmember = context.HttpContext.Session.GetObjectFromJson<Member>("MemberLog");

            if (tempmember == null)
            {
                context.Result = new RedirectResult("/Login/Index");
            }

        }
    }
}
