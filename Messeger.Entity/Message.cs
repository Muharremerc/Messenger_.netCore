using Messege.CORE.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.Entity
{
    public class Message:DefaultProperty
    {
        public string Header { get; set; }
        public string Desc { get; set; }
        public int MemberID { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<MessageDetails>MessageDetails { get; set; }
        public virtual ICollection<MessageMember> MessageMembers{ get; set; }
    }
}
