using Messeger.BLL.Interfaces.Services;
using Messeger.Entity;
using Messeger.MVC.NetCORE.UI.Helper;
using Messeger.MVC.NetCORE.UI.Validations.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.MVC.NetCORE.UI.Validations
{
  
    public sealed class UsernameValidation : ValidationAttribute
    {
        IMemberService _memberService;
        IHttpContextAccessor _session;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                _memberService = (IMemberService)validationContext
                                 .GetService(typeof(IMemberService));
                _session = (IHttpContextAccessor)validationContext
                  .GetService(typeof(IHttpContextAccessor));
                if (_memberService.Get(x => x.Username == value.ToString()) == null || _session.HttpContext.Session.GetObjectFromJson<Member>("MemberLog").Username == value.ToString())
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Username Error");
                }
            }
            return new ValidationResult("Username Error");
        }
    }
}
