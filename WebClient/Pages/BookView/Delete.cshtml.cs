using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebClient.Data;
using WebClient.Model;
using WebClient.Services;

namespace WebClient.Pages.BookView
{
    public class DeleteModel : PageModel
    {
        private readonly BookApiService _bookApiService;

        public DeleteModel(BookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookApiService.GetByIdAsync(id.Value);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookApiService.GetByIdAsync(id.Value);
            if (book != null)
            {
                await _bookApiService.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
