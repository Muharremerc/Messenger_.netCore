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
    public class MessageController : Controller
    {
        IMemberService _memberService;
        IMessageService _messageService;
        public MessageController(IMemberService memberService, IMessageService messageService)
        {
            _memberService = memberService;
            _messageService = messageService;
        }
        [Route("{id}")]
        [HttpGet]
        public List<MessagesMember> Get(int id)
        {
            List<MessagesMember> returnValue;
            var getValue = _messageService.GetAllMessageWithMemberInfo(id).ToList(); ;
            if (getValue.Count > 0)
            {
                returnValue = new List<MessagesMember>();
                foreach (var item in getValue)
                {
                    returnValue.Add(new MessagesMember
                    {
                        MemberID = item.Member.ID,
                        CreatedDate = item.CreatedDate,
                        Desc = item.Desc,
                        Header = item.Header,
                        Name = item.Member.Name,
                        Surname = item.Member.Surname,
                        MessageID = item.ID,
                        TextCount = item.MessageDetails.Count
                    });
                }
                return returnValue;
            }

            return null;
        }
        [Route("[action]")]
        [HttpPost]
        public bool Create(Model.DTO.Message message)
        {
            int id = _messageService.Add(new Entity.Message { Desc = message.Desc, Header = message.Header, MemberID = message.CreaterID });
            var messagetemp = _messageService.Get(id);
            if (messagetemp.MessageMembers == null)
            {
                messagetemp.MessageMembers = new List<MessageMember>();
            }
            messagetemp.MessageMembers.Add(new MessageMember { MemberID = message.CreaterID, MessageID = id });
            _messageService.Save();
            return true;
        }

        [HttpPost]
        public bool Send(SendMessage message)
        {
            var MessageTemp = _messageService.GetMessageDetailsWithMessageID(message.MessageID);
            MessageTemp.MessageDetails.Add(new Entity.MessageDetails
            {
                MemberID = message.MemberID,
                MessageID = message.MessageID,
                Text = message.Text
            });
            _memberService.Save();
            return true;
        }
        [Route("[action]")]
        [HttpPost]
        public InviteReturnData Invite(Invite inviteData)
        {
            var getData = _memberService.Get(x => x.TagName == inviteData.Tagname);
            if (getData != null)
            {
                var MessageData = _messageService.GetAllMessageWithMessageIDInfo(x => x.ID == inviteData.MessageID);
                int Contain = MessageData.MessageMembers.Where(x => x.MemberID == getData.ID).ToList().Count();
                if (Contain == 0)
                {
                    MessageData.MessageMembers.Add(new MessageMember { MemberID = getData.ID, MessageID = inviteData.MessageID });
                    _memberService.Save();
                    return new InviteReturnData() { MemberID = getData.ID, NameSurname = getData.Name + " " + getData.Surname };
                }
            }
            return null;
        }

        [Route("[action]")]
        [HttpPost]
        public bool Delete(Delete DeleteData)
        {
            var getData = _messageService.GetAllMessageWithMessageIDInfo(x => x.ID == DeleteData.MessageID);
            if (getData != null)
            {
                foreach (var item in getData.MessageMembers.ToList())
                {
                    
                    getData.MessageMembers.Remove(item);
                }
                _messageService.Delete(DeleteData.MessageID);
                _messageService.Save();
                return true;
            }
            return false;
        }
        [Route("[action]")]
        [HttpPost]
        public bool Leave(Delete DeleteData)
        {
            var getData = _messageService.GetAllMessageWithMessageIDInfo(x => x.ID == DeleteData.MessageID);
            if (getData != null)
            {
                if (getData.MessageMembers.Remove(getData.MessageMembers.Where(x => x.MemberID == DeleteData.MemberID && x.MessageID == DeleteData.MessageID).FirstOrDefault()))
                {
                    _messageService.Save();
                    return true;
                }
            }
            return false;
        }
    }
}