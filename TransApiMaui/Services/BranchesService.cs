using Newtonsoft.Json;
using TransApiMaui.Models;

namespace TransApiMaui.Services
{
    public class BranchesService : IBranchesRepository
    {
        public async Task<ResponseDto<List<BranchInfo>>> GetAll(string token)
        {
            var client = new HttpClient();

            string url = "http://10.0.2.2:5072/api/Branches";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(url);
            string responseContent = response.Content.ReadAsStringAsync().Result;
            ResponseDto<List<BranchInfo>> responseLogin = JsonConvert.DeserializeObject<ResponseDto<List<BranchInfo>>>(responseContent);
            return responseLogin;
        }
    }
}
