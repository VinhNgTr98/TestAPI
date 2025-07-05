namespace BookAPI.Repositories
{
    using BookAPI.Data;
    using BookAPI.Model;
    using BookAPI.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllAsync()
        {
            return  _context.Books.AsQueryable();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddAsync(Book Book)
        {
            await _context.Books.AddAsync(Book);
        }

        public void Update(Book Book)
        {
            _context.Books.Update(Book);
        }

        public void Delete(Book Book)
        {
            _context.Books.Remove(Book);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }

}
