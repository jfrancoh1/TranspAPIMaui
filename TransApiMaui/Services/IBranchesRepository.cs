using TransApiMaui.Models;

namespace TransApiMaui.Services
{
    public interface IUsersRepository
    {
        Task<ResponseDto<List<UserInfo>>> GetAll(string token);
    }
}
