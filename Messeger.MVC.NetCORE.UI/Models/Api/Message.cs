using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.MVC.NetCORE.UI.Models.Api
{
    public class Message
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Max Length 30")]
        public string Header { get; set; }
        [MaxLength(30, ErrorMessage = "Max Length 30")]
        [Required]
        public string Desc { get; set; }
        public int CreaterID { get; set; }
    }
}
