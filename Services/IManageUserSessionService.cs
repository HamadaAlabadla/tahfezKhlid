using Microsoft.EntityFrameworkCore;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageUserSessionService
    {
        Task<UserSession> CreateUserSession(string userId, int sessionId);
        Task<UserSession> GetUserSession(string userId, int sessionId);
        Task<UserSession> DeleteUserSession(UserSession userSession);
        Task<UserSession> UpdateUserSession(UserSession userSession);
    }

    public class ManageUserSessionService : IManageUserSessionService
    {
        readonly tahfezKhalidContext context;

        public ManageUserSessionService(tahfezKhalidContext context) => this.context = context;
        public async Task<UserSession> CreateUserSession(string userId, int sessionId)
        {
            var getUserSession = await context.UserSession.FirstOrDefaultAsync(x => x.userId == userId && x.sessionId == sessionId);

            if (getUserSession != null)
                return getUserSession;
            var getUserSessions = await context.UserSession.Where(x => x.sessionId == sessionId).ToListAsync();
            if(getUserSessions.Count >=14)
                return null;
            var userSession = new UserSession()
            {
                sessionId = sessionId,
                userId = userId,
            };

            await context.AddAsync(userSession);
            await context.SaveChangesAsync();
            return userSession;
        }

        public async Task<UserSession> DeleteUserSession(UserSession userSession)
        {
            var getUserSession = await context.UserSession.FirstOrDefaultAsync(x => x.userId == userSession.userId && x.sessionId == userSession.sessionId);

            if (getUserSession == null)
                throw new Exception("خطأ في الإدخال !!!");

            context.Remove(getUserSession);
            await context.SaveChangesAsync();
            return (UserSession)getUserSession;
        }

        public Task<UserSession> GetUserSession(string userId, int sessionId)
        {
            return context.UserSession.FirstOrDefaultAsync(x => x.userId == userId && x.sessionId == sessionId);
        }

        public async Task<UserSession> UpdateUserSession(UserSession userSession)
        {
            var getUserSession = context.UserSession.Where(x => x.userId == userSession.userId && x.sessionId == userSession.sessionId);

            if (getUserSession == null)
                throw new Exception("خطأ في الإدخال !!!");

            context.Update(getUserSession);
            await context.SaveChangesAsync();
            return (UserSession)getUserSession;
        }
    }
}