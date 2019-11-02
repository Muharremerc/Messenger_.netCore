using Messege.CORE.Interfaces;
using Messeger.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.DAL.Interfaces
{
    public interface EF_IMemberRepository:EF_IRepository<Member,Messeger_DBContext>
    {
        Member getMemberMessageList(int id);
    }

   
}
