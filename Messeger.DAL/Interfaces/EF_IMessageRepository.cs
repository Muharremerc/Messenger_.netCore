using Messege.CORE.Interfaces;
using Messeger.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Messeger.DAL.Interfaces
{
    public interface EF_IMessageRepository:EF_IRepository<Message,Messeger_DBContext>
    {
        List<Message> GetAllMessageWithMemberInfo(int MemberID);
        Message GetAllMessageWithMessageIDInfo(Expression<Func<Message, bool>> expression);
        Message GetMessageDetailsWithMessageID(int MessageID);
    }
}
