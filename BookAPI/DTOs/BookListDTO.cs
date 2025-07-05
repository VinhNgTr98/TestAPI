namespace BookAPI.DTOs
{
    public class BookListDTO
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateOnly CreatedAt { get; set; }
    }
}
