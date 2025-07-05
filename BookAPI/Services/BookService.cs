namespace BookAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BookAPI.DTOs;
    using BookAPI.Model;
    using BookAPI.Repositories.Interfaces;
    using BookAPI.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IQueryable<BookReadDTO> GetAllBooksAsync()
        {
            var books =  _bookRepository.GetAllAsync();
            return books.ProjectTo<BookReadDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<BookReadDTO?> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;
            return _mapper.Map<BookReadDTO>(book);
        }

        public async Task<BookReadDTO> CreateBookAsync(BookCreateDTO bookCreateDto)
        {
            var book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();
            return _mapper.Map<BookReadDTO>(book);
        }

        public async Task<bool> UpdateBookAsync(BookUpdateDTO bookUpdateDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(bookUpdateDto.Id);
            if (existingBook == null) return false;

            _mapper.Map(bookUpdateDto, existingBook);
            _bookRepository.Update(existingBook);
            return await _bookRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null) return false;

            _bookRepository.Delete(existingBook);
            return await _bookRepository.SaveChangesAsync();
        }
    }

}
