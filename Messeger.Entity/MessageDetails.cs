using Messege.CORE.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.Entity
{
    public class MessageDetails:DefaultProperty
    {
        public string Text { get; set; }
        public int MemberID { get; set; }
        public int MessageID { get; set; }

        public virtual Member Member { get; set; }
        public virtual Message Message { get; set; }
    }
}
