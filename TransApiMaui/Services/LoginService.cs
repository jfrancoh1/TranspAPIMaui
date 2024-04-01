using System.Text;
using TransApiMaui.Models;
using Newtonsoft.Json;

namespace TransApiMaui.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<ResponseDto<ResponseLogin>> Login(string userId, string password)
        {
            
            var client = new HttpClient();

            string url = "http://10.0.2.2:5072/api/Authentication/Login";
            client.BaseAddress = new Uri(url);
            var content = new StringContent(
                "{ \"id\": \"" + userId + "\", \"password\": \"" + password + "\" }",
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = response.Content.ReadAsStringAsync().Result;
            ResponseDto<ResponseLogin> responseLogin = JsonConvert.DeserializeObject<ResponseDto<ResponseLogin>>(responseContent);
            if (responseLogin?.Data?.token != null)
            {
                await SaveTokenAndUserId(responseLogin.Data.token, responseLogin.Data.user.id.ToString());
            }
            return responseLogin;
        }


        private async Task SaveTokenAndUserId(string token, string userId)
        {
            await SecureStorage.SetAsync("AuthToken", token);
            await SecureStorage.SetAsync("UserId", userId);
        }

        public async Task<string> GetAuthToken()
    {
        return await SecureStorage.GetAsync("AuthToken");
    }
    }
}
