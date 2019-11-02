using Messege.CORE.EFRepository;
using Messeger.DAL.Interfaces;
using Messeger.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Messeger.DAL.Repositories
{
    public class EF_MessageRepository : EF_Repository<Message, Messeger_DBContext>, EF_IMessageRepository
    {
        Messeger_DBContext _Messeger_DBContext;
        public EF_MessageRepository(Messeger_DBContext dbContext) : base(dbContext)
        {
            _Messeger_DBContext = dbContext;
        }

        public List<Message> GetAllMessageWithMemberInfo(int MemberID)
        {
            var GetMessageList = _Messeger_DBContext.MessageMembers.Where(u => u.MemberID == MemberID).Select(y=>y.MessageID).ToList();
            return _Messeger_DBContext.Messages.Include(x => x.Member).Include(x=>x.MessageDetails).Include(x=>x.MessageMembers).Where(x=> GetMessageList.Contains(x.ID)).ToList();
        }

        public Message GetAllMessageWithMessageIDInfo(Expression<Func<Message, bool>> expression)
        {
            var retunvalue = _Messeger_DBContext.Messages.Include(x => x.Member).Include(x => x.MessageDetails).Include("MessageDetails.Member").Include("MessageMembers.Member").Include(x=>x.MessageMembers).Where(expression).FirstOrDefault();
            

            return retunvalue;
        }

        public Message GetMessageDetailsWithMessageID(int MessageID)
        {
            return _Messeger_DBContext.Messages.Include(x => x.MessageDetails).Where(x => x.ID == MessageID).FirstOrDefault();
        }
    }
}
