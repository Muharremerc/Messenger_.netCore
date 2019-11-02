using Messeger.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Helper;
using Microsoft.AspNetCore.Http;
using Messeger.Entity;

namespace Messeger.MVC.NetCORE.UI.Validations
{
    public class TagnameValidation : ValidationAttribute
    {
        IMemberService _memberService;
        IHttpContextAccessor _session;
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value !=null)
            {
                _memberService = (IMemberService)validationContext
                     .GetService(typeof(IMemberService));
                _session = (IHttpContextAccessor)validationContext
                    .GetService(typeof(IHttpContextAccessor));
                if (_memberService.Get(x => x.TagName == value.ToString()) == null || _session.HttpContext.Session.GetObjectFromJson<Member>("MemberLog").TagName==value.ToString())
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Tagname Error");
                } 
            }
            return new ValidationResult("Tagname Error");
        }
    }
}
