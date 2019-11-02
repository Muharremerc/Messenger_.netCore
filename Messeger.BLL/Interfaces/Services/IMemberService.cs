using Messeger.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.BLL.Interfaces.Services
{
    public interface IMemberService:IServiceRepository<Member>
    {
        Member getMemberMessageList(int id);
    }
}
