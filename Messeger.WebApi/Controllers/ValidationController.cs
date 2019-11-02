using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messeger.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messeger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        IMemberService _memberService; 
        public ValidationController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [Route("[action]")]
        [HttpPost]
        public bool Username(string username)
        {
            if (_memberService.Get(x => x.Username == username) != null)
                return true;
            return false;
        }

        [Route("[action]")]
        [HttpPost]
        public bool Email(string email)
        {
            if (_memberService.Get(x => x.Email == email) != null)
                return true;
            return false;
        }

        [Route("[action]")]
        [HttpPost]
        public bool Tagname(string tagName)
        {
            if (_memberService.Get(x => x.TagName == tagName) != null)
                return true;
            return false;
        }
    }
}