using Microsoft.AspNetCore.Authentication;
using AuthAPI.Services.Interfaces;
using AuthAPI.Repositories.Interfaces;
using AutoMapper;
using AuthAPI.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthAPI.Models;
namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IMapper mapper, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDTO dto)
        {
            // Check if username already exists
            var existingUser = await _authRepository.GetByUsernameAsync(dto.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");
            }

            // Create new Accounts from DTO
            var Accounts = _mapper.Map<Accounts>(dto);

            // Hash password using BCrypt.Net
            Accounts.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Save Accounts to database
            await _authRepository.AddAsync(Accounts);

            // Return
            return "Accounts registered successfully";
        }




        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var Accounts = await _authRepository.GetByUsernameAsync(dto.Username);
            // nếu Accounts = null hoặc không đúng password thì trả về lỗi
            if (Accounts == null || !BCrypt.Net.BCrypt.Verify(dto.Password, Accounts.Password))
            {
                throw new UnauthorizedAccessException("Sai tên đăng nhập hoặc mật khẩu chưa đúng.");
            }
            var token = await GenerateJwtTokenAsync(Accounts);
            return token;
        }


        public Task<string> GenerateJwtTokenAsync(Accounts user)
        {
            // Lấy key từ appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            // Tạo Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Ký token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Thời gian sống token
                signingCredentials: creds
            );
            // Chuyển token thành string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(tokenString);
        }
    }

}
