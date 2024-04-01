using TransApiMaui.Models;

namespace TransApiMaui.Services
{
    public interface ILoginRepository
    {
        Task<ResponseDto<ResponseLogin>> Login(string userId, string password);
        Task<string> GetAuthToken();
    }
}
