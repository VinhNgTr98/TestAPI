using AuthAPI.Data;
using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace AuthAPI.Repositories
{
    public class AuthRepository : Interfaces.IAuthRepository
    {
        private readonly AuthAPIContext _context;

        public AuthRepository(AuthAPIContext context)
        {
            _context = context;
        }

        public IQueryable<Accounts> GetAll()
        {
            return _context.Accounts.AsQueryable();
        }

        /*  public async Task<int> GetCountAsync()
          {  return await _context.Accounts.CountAsync(); }*/

        public async Task<Accounts?> GetByIdAsync(Guid id)
            => await _context.Accounts.FindAsync(id);

        public async Task AddAsync(Accounts student)
        {
            await _context.Accounts.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Accounts student)
        {
            _context.Accounts.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Accounts student)
        {
            _context.Accounts.Remove(student);
            await _context.SaveChangesAsync();
        }

       /* public Task<Accounts?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }*/
        public async Task<Accounts?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }


        public async Task<Accounts?> GetByUsernameAsync(string name)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == name);
        }

    }


}
