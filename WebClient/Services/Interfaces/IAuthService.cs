using WebClient.DTOs;

namespace WebClient.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDTO dto);
        Task<bool> LoginAsync(LoginDTO dto);
        Task<bool> LogoutAsync();
    }

}
