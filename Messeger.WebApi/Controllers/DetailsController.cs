using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messeger.BLL.Interfaces.Services;
using Messeger.WebApi.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messeger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        IMessageService _messageService;
        public DetailsController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Route("{id}")]
        [HttpGet]
        public MessagesDetailsMember GetMessagesDetails(int id)
        {
            MessagesDetailsMember returnValue = new MessagesDetailsMember();
            var GetValue = _messageService.GetAllMessageWithMessageIDInfo(x => x.ID == id);
            if (GetValue != null)
            {
                returnValue.DataMessageMemberDetails = new MessagesMember()
                {
                    Header = GetValue.Header,
                    Desc = GetValue.Desc,
                    CreatedDate = GetValue.CreatedDate,
                    MemberID = GetValue.MemberID,
                    MessageID = GetValue.ID,
                    Name = GetValue.Member.Name,
                    Surname = GetValue.Member.Surname
                };
                if (GetValue.MessageDetails.Count > 0)
                {
                    returnValue.DataMessageDetails = new List<MessageDetails>();
                    foreach (var item in GetValue.MessageDetails.OrderByDescending(x => x.CreatedDate))
                    {
                        returnValue.DataMessageDetails.Add(new MessageDetails
                        {
                            CreaterDate = item.CreatedDate,
                            ID = item.ID,
                            MemberID = item.MemberID,
                            Name = item.Member.Name,
                            Surname = item.Member.Surname,
                            Text = item.Text
                        });
                    }
                }

                    returnValue.DataMembers = new List<Members>();
                    if (GetValue.MessageMembers.Count > 0)
                    {
                        foreach (var item in GetValue.MessageMembers)
                        {
                            returnValue.DataMembers.Add(new Members
                            {

                                ID = item.ID,
                                Name = item.Member.Name,
                                Surname = item.Member.Surname
                            });
                        }
                    }

                
            }
            return returnValue;

        }
    }
}