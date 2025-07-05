using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebClient.Data;
using WebClient.Model;
using WebClient.Services;

namespace WebClient.Pages.BookView
{
    public class EditModel : PageModel
    {
        private readonly BookApiService _bookApiService;

        public EditModel(BookApiService bookApiService)
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
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            

            try
            {
                await _bookApiService.UpdateAsync(Book);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error updating student.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
