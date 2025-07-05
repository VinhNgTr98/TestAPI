using AuthAPI.DTOs;
using AuthAPI.Models;

namespace AuthAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
        Task<string> GenerateJwtTokenAsync(Accounts user); //Generate a JWT token
                                                       //Có thể tạo thêm các action giống Repositories 

    }
}
