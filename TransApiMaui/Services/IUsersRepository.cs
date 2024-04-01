using TransApiMaui.Models;

namespace TransApiMaui.Services
{
    public interface IBranchesRepository
    {
        Task<ResponseDto<List<BranchInfo>>> GetAll(string token);
    }
}
