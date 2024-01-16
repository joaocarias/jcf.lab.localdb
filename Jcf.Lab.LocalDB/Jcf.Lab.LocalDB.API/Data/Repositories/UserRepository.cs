using Jcf.Lab.LocalDB.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.LocalDB.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appContext;

        public UserRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<User?> AddAsync(User entidade)
        {
            try
            {
                await _appContext.Users.AddAsync(entidade);
                await _appContext.SaveChangesAsync();

                return entidade;
            }
            catch 
            {                
                return null;
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            try
            {
                return await _appContext.Users
                                .AsNoTracking()                                
                                .ToListAsync();
            }
            catch
            {            
                return Enumerable.Empty<User>();
            }
        }
    }
}
