using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.MVC.NetCORE.UI.Validations.API
{
    public interface IApiValidation
    {
        Task<bool> Username(string username);
        Task<bool> Email(string email);
        Task<bool> Tagname(string tagName);
    }
}
