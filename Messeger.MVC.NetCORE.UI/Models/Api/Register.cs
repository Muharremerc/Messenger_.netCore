using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Messeger.MVC.NetCORE.UI.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Messeger.MVC.NetCORE.UI.Models.Api
{
    public class Register
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        public string Surname { get; set; }
        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(5, ErrorMessage = "Min Length is 5")]
        [TagnameValidation]
        public string TagName { get; set; }
        [Required]
        [EmailValidation]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(5, ErrorMessage = "Min Length is 5")]
        [UsernameValidation]
        public string Username { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(5, ErrorMessage = "Min Length is 5")]
        public string Password { get; set; }
    }
}
