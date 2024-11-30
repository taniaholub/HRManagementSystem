using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;


namespace DAL.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }

    // Отримати список користувачів за роллю
    public IEnumerable<User> GetUsersByRole(string role)
    {
        return db.Users.Where(user => user.Role == role).ToList();
    }

    // Знайти користувача за електронною поштою
    public User FindByEmail(string email)
    {
        return db.Users.FirstOrDefault(user => user.Email == email);
    }

    // Отримати користувачів, які створили запити за останній місяць
    public IEnumerable<User> GetActiveUsers(DateTime fromDate)
    {
        return db.Users
                 .Where(user => user.UserRequests.Any(req => req.CreatedAt >= fromDate))
                 .ToList();
    }
}
