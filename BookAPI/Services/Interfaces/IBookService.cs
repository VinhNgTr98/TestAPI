namespace BookAPI.Services.Interfaces
{
    using BookAPI.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookService
    {
        IQueryable<BookReadDTO> GetAllBooksAsync();
        Task<BookReadDTO?> GetBookByIdAsync(Guid id);
        Task<BookReadDTO> CreateBookAsync(BookCreateDTO bookCreateDto);
        Task<bool> UpdateBookAsync(BookUpdateDTO bookUpdateDto);
        Task<bool> DeleteBookAsync(Guid id);
    }

}
