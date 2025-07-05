namespace BookAPI.Repositories.Interfaces
{
    using BookAPI.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        IQueryable<Book> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task<bool> SaveChangesAsync();
    }
}
