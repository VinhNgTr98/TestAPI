using WebClient.DTOs;
using WebClient.Services.Interfaces;

namespace WebClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7030/api/Auth/");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> LoginAsync(LoginDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("login", dto);

            if (response.IsSuccessStatusCode)
            {
                var authResult = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (authResult != null && !string.IsNullOrEmpty(authResult.Token))
                {
                    var httpContext = _httpContextAccessor.HttpContext;

                    httpContext?.Session.SetString("authToken", authResult.Token);
                    httpContext?.Response.Cookies.Append("Username", dto.Username);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> LogoutAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            context?.Session.Remove("authToken");
            context?.Response.Cookies.Delete("Username");
            return await Task.FromResult(true);
        }

        public async Task<bool> RegisterAsync(RegisterDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("register", dto);
            return response.IsSuccessStatusCode;
        }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
    }
}
