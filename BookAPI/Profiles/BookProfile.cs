namespace BookAPI.Profiles
{
    using AutoMapper;
    using BookAPI.DTOs;
    using BookAPI.Model;
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // CreateDTO -> Book
            CreateMap<BookCreateDTO, Book>();

            // Book -> ReadDTO
            CreateMap<Book, BookReadDTO>();

            // Book -> ListDTO
            CreateMap<Book, BookListDTO>();

            // UpdateDTO -> Book
            CreateMap<BookUpdateDTO, Book>();
        }
    }
}
