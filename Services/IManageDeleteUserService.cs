using Microsoft.EntityFrameworkCore;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageDeleteUserService
    {
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AddUserAsync(string userId);
        Task<bool> FindUserAsync(string userId);
        List<string> GetAllUserAsync();
    }

    public class ManageDeleteUserService : IManageDeleteUserService
    {
        readonly tahfezKhalidContext context;

        public ManageDeleteUserService(tahfezKhalidContext context) => this.context = context;

        public async Task<bool> AddUserAsync(string userId)
        {
            var unDeleted = await context.DeletedUsers.FirstOrDefaultAsync(x => x.userId == userId);

            if (unDeleted == null)
                return false;

            context.Remove(unDeleted);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var Deleted = await context.DeletedUsers.FirstOrDefaultAsync(x => x.userId == userId);

            if (Deleted != null)
                return false;

            var deleted = new DeletedUser()
            {
                userId = userId,
            };

            await context.AddAsync(deleted);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FindUserAsync(string userId)
        {
            var getUser = await context.DeletedUsers.FirstOrDefaultAsync(x => x.userId == userId);

            if (getUser == null)
                return false;
            else
                return true;
        }

        public List<string> GetAllUserAsync()
        {
            var users = context.DeletedUsers.Select(x => x.userId).ToList();
            return users;
        }
    }
}