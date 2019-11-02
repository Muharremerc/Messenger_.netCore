using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messeger.BLL.Interfaces.Services;
using Messeger.Entity;
using Messeger.WebApi.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Messeger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        public class LoginPostModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public Member GetData(int id)
        {
            return _memberService.Get(1);
        }

        [HttpPost]
        public Member Post(LoginPostModel model)
        {
            return _memberService.Get(x => x.Username == model.Username && x.Password == model.Password);
        }

        [HttpPost]
        [Route("[action]")]
        public bool Register(Register member)
        {
            var MessageTemp = _memberService.Add(new Member {

                Name=member.Name,
                Phone=member.Phone,
                Username=member.Username,
                Surname=member.Surname,
                Email=member.Email,
                Password=member.Password,
                TagName=member.TagName
            });
            _memberService.Save();
            return true;
        }

        [HttpPost]
        [Route("[action]")]
        public bool Update(Register member)
        {
            var tempMember = _memberService.Get(x => x.ID == member.ID);
            tempMember.Name = member.Name;
            tempMember.Phone = member.Phone;
            tempMember.Username = member.Username;
            tempMember.Surname = member.Surname;
            tempMember.Email = member.Email;
            tempMember.Password = member.Password;
            tempMember.TagName = member.TagName;
            _memberService.Update(tempMember);
            _memberService.Save();
            return true;
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
