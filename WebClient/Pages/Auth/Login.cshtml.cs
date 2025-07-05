using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClient.DTOs;
using WebClient.Services.Interfaces;

namespace WebClient.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public LoginDTO LoginDto { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _authService.LoginAsync(LoginDto);

            if (result)
                return RedirectToPage("/Index");

            ErrorMessage = "Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.";
            return Page();
        }
    }

}
