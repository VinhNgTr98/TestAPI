using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebClient.Services;
using WebClient.Model;

namespace WebClient.Pages.BookView
{
    public class DetailsModel : PageModel
    {
        private readonly BookApiService _bookApiService;

        public DetailsModel(BookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }

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
    }
}
