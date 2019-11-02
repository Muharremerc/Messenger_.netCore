using Messege.CORE.EFRepository;
using Messeger.DAL.Interfaces;
using Messeger.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messeger.DAL.Repositories
{
    public class EF_MemberRepository : EF_Repository<Member, Messeger_DBContext>, EF_IMemberRepository
    {
        Messeger_DBContext _Messeger_DBContext;
        public EF_MemberRepository(Messeger_DBContext dbContext) : base(dbContext)
        {
            _Messeger_DBContext = dbContext;
        }

        public Member getMemberMessageList(int id)
        {
            return _Messeger_DBContext.Members.Include(x => x.Messages).Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
