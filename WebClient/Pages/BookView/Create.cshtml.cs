using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Data;
using WebClient.Model;
using WebClient.Services;

namespace WebClient.Pages.BookView
{
    public class CreateModel : PageModel
    {
        private readonly BookApiService _bookApiService;

        public CreateModel(BookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }
        [BindProperty]
        public Book Book { get; set; } = default!;
        public IActionResult OnGet()
        {
            
            return Page();
        }

        

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Book.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
            await _bookApiService.CreateAsync(Book);

            return RedirectToPage("./Index");
        }
    }
}
