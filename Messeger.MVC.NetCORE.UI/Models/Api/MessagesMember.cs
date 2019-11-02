using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.MVC.NetCORE.UI.Models.Api
{
    public class MessagesMember
    {
        public int MessageID { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Desc { get; set; }
        public int TextCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastTextDate { get; set; }
    }
}
