using Messege.CORE.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.Entity
{
    public class Member:DefaultProperty
    {
        public Member()
        {
                
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TagName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public virtual ICollection<Message> Messages{ get; set; }
        public virtual ICollection<MessageDetails>MessageDetails { get; set; }
        public virtual ICollection<MessageMember>MessageMembers { get; set; }
    }
}
