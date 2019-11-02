using Messeger.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Messeger.BLL.Interfaces.Services
{
    public interface IMessageService:IServiceRepository<Message>
    {
        List<Message> GetAllMessageWithMemberInfo(int MemberID);
       Message GetAllMessageWithMessageIDInfo(Expression<Func<Message, bool>> expression);
        Message GetMessageDetailsWithMessageID(int MessageID);
    }
}
