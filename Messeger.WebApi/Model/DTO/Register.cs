using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.WebApi.Model.DTO
{
    public class Register
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TagName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
