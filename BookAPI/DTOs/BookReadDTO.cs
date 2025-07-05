namespace BookAPI.DTOs
{
    public class BookReadDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateOnly CreatedAt { get; set; }
    }
}
