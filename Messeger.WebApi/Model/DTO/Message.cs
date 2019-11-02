using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.WebApi.Model.DTO
{
    public class Message
    {
        public string Header { get; set; }
        public string Desc { get; set; }
        public int CreaterID { get; set; }
        
    }
}
