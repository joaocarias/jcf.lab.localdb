using Jcf.Lab.LocalDB.API.Entities;

namespace Jcf.Lab.LocalDB.API.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AddAsync(User user);
        Task<IEnumerable<User>> ListAsync();
    }
}