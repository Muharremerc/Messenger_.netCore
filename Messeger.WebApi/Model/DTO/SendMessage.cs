using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.WebApi.Model.DTO
{
    public class SendMessage
    {
        public string Text { get; set; }
        public int MemberID { get; set; }
        public int MessageID { get; set; }
    }
}
