using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransApiMaui.Models;

namespace TransApiMaui.Services
{
    public class UsersService : IUsersRepository
    {
        public async Task<ResponseDto<List<UserInfo>>> GetAll(string token)
        {
            var client = new HttpClient();

            string url = "http://10.0.2.2:5072/api/Users";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(url);
            string responseContent = response.Content.ReadAsStringAsync().Result;
            ResponseDto<List<UserInfo>> responseLogin = JsonConvert.DeserializeObject<ResponseDto<List<UserInfo>>>(responseContent);
            return responseLogin;
        }
    }
}
