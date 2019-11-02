using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Messeger.MVC.NetCORE.UI.Validations.API
{
    public sealed class ApiValidation : IApiValidation
    {

        public async Task<bool> Username(string username)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(username), Encoding.UTF8, "application/json");
                using (var response = httpClient.PostAsync("https://localhost:44309/api/Member", content))
                {
                }
            }
            return true;
        }
        public async Task<ValidationResult> Email(string email)
        {
            bool result;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
                using (var response =await httpClient.PostAsync("https://localhost:44309/api/Member", content))
                {
                    string apiResponse =await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            if (result)
                return ValidationResult.Success;
            return new ValidationResult("Tagname Error");
        }
        public async Task<bool> Tagname(string tagName)
        {
            return true;
        }

        Task<bool> IApiValidation.Email(string email)
        {
            throw new NotImplementedException();
        }
    }
}
