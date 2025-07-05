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
    public class IndexModel : PageModel
    {
        private readonly BookApiService _bookApiService;

        public IndexModel(BookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }

        public IList<Book> Book { get; set; } = new List<Book>();

        [BindProperty(SupportsGet = true)]
        public int Page { get; set; } = 1;

        public const int PageSize = 10;

        public int TotalCount { get; set; }

        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page * PageSize < TotalCount;

        public async Task<IActionResult> OnGetAsync()
        {
            if (Request.Query.ContainsKey("Page") && int.TryParse(Request.Query["Page"], out int page))
            {
                Page = page;
            }
            int skip = (Page - 1) * PageSize;

            var result = await _bookApiService.GetPagedAsync(skip, PageSize);

            Book = result.Value;
            TotalCount = result.Count;

            return Page();
        }


    }

}
