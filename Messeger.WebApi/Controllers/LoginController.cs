using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messeger.BLL.Interfaces.Services;
using Messeger.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Messeger.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        IMemberService _memberService;
        public LoginController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return _memberService.Get(id);
        }
        [HttpPost]
        public Member LoginMember(string username,string password)
        {
            return _memberService.Get(x=>x.Username==username && x.Password==password);
        }
    }
}