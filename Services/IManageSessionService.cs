using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tahfez.Models;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageSessionService
    {
        Task<Session> GetSession(int sessionId);
        Task<Session> GetLastSession();
        Task<List<Session>> GetAllSessionsAsync();
        Task<List<Session>> GetAllSessionsByMemorizerIdAsync(string memorizerId);
        Task<Session> DeleteSessionAsync(Session session);
        Task<Session> UpdateSessionAsync(Session session);
        Task<Session> CreateSessionAsync(Session session);
        Task<List<User>> GetAllParentBySessionId(int sessionId);

    }

    public class ManageSessionService : IManageSessionService
    {
        readonly tahfezKhalidContext context;
        readonly UserManager<User> userManger;

        public ManageSessionService(tahfezKhalidContext context,
            UserManager<User> userManager)
        {
            this.context = context;
            userManger = userManager;
        }
        public async Task<Session> CreateSessionAsync(Session session)
        {
            var getSession = await GetSession(session.Id);

            if (getSession != null)
                throw new Exception("الحلقة مضافة مسبقا");

            session.Status = state.فعال;
            await context.AddAsync(session);
            await context.SaveChangesAsync();
            getSession = await GetSession(session.Id);
            return getSession;
        }

        public async Task<Session> DeleteSessionAsync(Session session)
        {
            var getSession = await GetSession(session.Id);

            if (getSession == null)
                throw new Exception("الحلقة غير موجودة !!!");

            getSession.Status = state.غير_فعال;
            await UpdateSessionAsync(getSession);
            return session;
        }

        public async Task<List<User>> GetAllParentBySessionId(int sessionId)
        {
            var getSession = await GetSession(sessionId);
            var parents = getSession.UserSessions.Where(x => x.user.TypeUser == TypeUser.ولي_أمر).ToList();

            if (parents == null)
                return null;

            return parents.Select(x => x.user).ToList();
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            var sessions = await context.Session.Include(x => x.Students).Include(x => x.UserSessions).ToListAsync();

            foreach (var session in sessions)
            {
                foreach (var item in session.UserSessions)
                    item.user = userManger.Users.Include(x => x.UserSessions).Include(x => x.Students).FirstOrDefault(x=> x.Id == item.userId);
                
            }

            return sessions;
        }

        public async Task<List<Session>> GetAllSessionsByMemorizerIdAsync(string memorizerId)
        {
            var sessions = await context.Session.Include(x => x.Students).Include(x => x.UserSessions).ToListAsync();
            var newSessions = new List<Session>();

            if (sessions != null)
            {
                foreach (var session in sessions)
                {
                    var check = session.UserSessions.FirstOrDefault(x => x.userId == memorizerId);

                    if (check != null)
                    {
                        var userCheck = await userManger.FindByIdAsync(check.userId);
                        var check2 = userCheck.TypeUser == TypeUser.محفظ;

                        if (check2)
                        {
                            foreach (var item in session.UserSessions)
                                item.user = await userManger.FindByIdAsync(item.userId);
                            

                            newSessions.Add(session);
                        }
                    }
                }
            }

            return newSessions;
        }

        public async Task<Session> GetLastSession()
        {
            if ((await GetAllSessionsAsync()).Count() == 0)
                return null;

            var sessions = await context.Session.Include(x => x.UserSessions).OrderBy(x => x.Id).LastAsync();

            if (sessions != null)
            {
                foreach (var item in sessions.UserSessions)
                    item.user = await userManger.FindByIdAsync(item.userId);
                
            }

            return sessions;
        }

        public async Task<Session> GetSession(int sessionId)
        {
            var sessions = await context.Session.Include(x => x.Students).Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == sessionId);

            if (sessions != null)
            {
                foreach (var item in sessions.UserSessions)
                    item.user = await userManger.FindByIdAsync(item.userId);
                
            }

            return sessions;
        }

        public async Task<Session> UpdateSessionAsync(Session session)
        {
            var getSession = await GetSession(session.Id);

            if (getSession == null)
                throw new Exception("الحلقة غير موجودة !!!");

            getSession.Name = session.Name;
            getSession.NumberExams = session.NumberExams;
            getSession.StudentsNumber = session.StudentsNumber;
            getSession.NumberPages = session.NumberPages;
            getSession.StayNumberExams = session.StayNumberExams;
            //getSession.UserSessions = new List<UserSession>();

            //foreach (var item in session.UserSessions)
            //    getSession.UserSessions.Add(item);
            

            context.Update(getSession);
            await context.SaveChangesAsync();
            return getSession;
        }
    }
}