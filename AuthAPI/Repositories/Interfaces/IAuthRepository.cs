using AuthAPI.Models;

namespace AuthAPI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        IQueryable<Accounts> GetAll();
        //Task<int> GetCountAsync();  //Khi nào có Odata thì sử dụng
        Task<Accounts?> GetByIdAsync(int id);
        Task AddAsync(Accounts item);
        Task UpdateAsync(Accounts item);
        Task DeleteAsync(Accounts item);
        Task<Accounts?> GetByUsernameAsync(string name); //Đặc trưng

    }
}
