
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using WebClient.Model;
namespace WebClient.Services   

{
    public class BookApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseUrl = "https://localhost:7060/api/Books";

        public BookApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        private void AttachToken()
        {
            var token = _httpContextAccessor.HttpContext?.Session?.GetString("authToken");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            AttachToken();
            return await _httpClient.GetFromJsonAsync<List<Book>>(_baseUrl);
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            AttachToken();
            return await _httpClient.GetFromJsonAsync<Book>($"{_baseUrl}/{id}");
        }

        public async Task CreateAsync(Book book)
        {
            AttachToken();
            await _httpClient.PostAsJsonAsync(_baseUrl, book);
        }

        public async Task UpdateAsync(Book book)
        {
            AttachToken();
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/{book.Id}", book);
        }

        public async Task DeleteAsync(Guid id)
        {
            AttachToken();
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }
        public async Task<ODataPagedResult<Book>> GetPagedAsync(int skip, int top)
        {
            AttachToken();
            var response = await _httpClient.GetFromJsonAsync<ODataPagedResult<Book>>(
    $"https://localhost:7060/odata/Books?$skip={skip}&$top={top}&$count=true");

            return response ?? new ODataPagedResult<Book>();
        }

        public class ODataPagedResult<T>
        {
            [JsonPropertyName("@odata.count")]
            public int Count { get; set; }

            [JsonPropertyName("value")]
            public List<T> Value { get; set; } = new();
        }

    }
}
