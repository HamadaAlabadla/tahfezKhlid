using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tahfez.Models;
using tahfezKhalid.Data;
using tahfezKhalid.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Controllers
{
    [Authorize]
    public class SessionsController : Controller
    {
        readonly IManageSessionService context;
        readonly IManageUserSessionService contextUserSession;
        readonly UserManager<User> userManager;
        readonly tahfezKhalidContext contextDB;

        public SessionsController(IManageSessionService context,
            UserManager<User> userManager,
            IManageUserSessionService contextUserSession,
            tahfezKhalidContext contextDB)
        {
            this.context = context;
            this.userManager = userManager;
            this.contextUserSession = contextUserSession;
            this.contextDB = contextDB;
        }
        [Authorize(Roles = "admin")]
        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            return View(await context.GetAllSessionsAsync());
        }

        // GET: Sessions/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //    if (id == null ||(await _context.GetAllSessionsAsync() )== null)
        //    {
        //        return NotFound();
        //    }

        //    var session = await _context.GetSession((int)id);
        //    if (session == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(session);
        // }

        // GET: Sessions/Create

        [Authorize(Roles = "admin,memorizer")]
        public async Task<IActionResult> IndexWithMemorizer(string Id)
        {
            var userMemorizer = await userManager.Users.Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == Id);
            var sessions = new List<Session>();

            if (userMemorizer.TypeUser == TypeUser.محفظ)
            {
                foreach (var item in userMemorizer.UserSessions)
                {
                    var session = await context.GetSession(item.sessionId);
                    sessions.Add(session);
                }
            }

            return View(sessions);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var userMem = userManager.Users.Where(x => x.TypeUser == TypeUser.محفظ);
            var userSup = userManager.Users.Where(x => x.TypeUser == TypeUser.مشرف);
            if (userMem != null)
                ViewData["userMemorizers"] = new SelectList(userMem, "Id", "Name");
            else
            {
                ModelState.AddModelError(string.Empty, "No Memorizer in System");
                ViewData["userMemorizers"] = null;
            }

            if (userSup != null)
                ViewData["userSupervisors"] = new SelectList(userSup, "Id", "Name");
            else
            {
                ModelState.AddModelError(string.Empty, "No Supervisors in System");
                ViewData["userSupervisors"] = null;
            }


            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(string memorizerId, string supervisorId, [Bind("Id,Name,NumberPages")] Session session)
        {
            if (ModelState.IsValid)
            {
                // var getLast = await _context.GetLastSession();
                // if (getLast == null)
                //    session.Id = 0;
                // else
                //    session.Id = getLast.Id + 1;
                session.Status = state.فعال;
                session.CreationDate = DateTime.Now;
                session.NumberExams = 0;
                session.StayNumberExams = 0;
                var addedSession = await context.CreateSessionAsync(session);
                await contextUserSession.CreateUserSession(memorizerId, addedSession.Id);
                await contextUserSession.CreateUserSession(supervisorId, addedSession.Id);
                return RedirectToAction(nameof(Index));
            }

            var userMemorizer = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.محفظ);
            var userSupervisor = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.مشرف);
            ViewData["userMemorizers"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.محفظ), "Id", "Name", userMemorizer.userId);
            ViewData["userSupervisors"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.مشرف), "Id", "Name", userSupervisor.userId);
            return View(session);
        }

        // GET: Sessions/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || (await context.GetAllSessionsAsync()) == null)
            {
                return NotFound();
            }

            var session = await context.GetSession((int)id);

            if (session == null)
            {
                return NotFound();
            }

            var userMemorizer = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.محفظ);
            var userSupervisor = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.مشرف);
            if (userMemorizer != null)
                ViewData["userMemorizers"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.محفظ), "Id", "Name", userMemorizer.userId);
            else
                ViewData["userMemorizers"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.محفظ), "Id", "Name");

            if (userSupervisor != null)
                ViewData["userSupervisors"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.مشرف), "Id", "Name", userSupervisor.userId);
            else
                ViewData["userSupervisors"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.مشرف), "Id", "Name");
            var oldMem = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.محفظ);
            var oldSup = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.مشرف);
            if(oldMem != null)
                ViewData["oldMemorizerId"] = oldMem.userId;
            if(oldSup != null)
                ViewData["oldSupervisorId"] = oldSup.userId;
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, string memorizerId, string oldMemorizerId, string oldSupervisorId, string supervisorId, [Bind("Id,Name,NumberPages,CreationDate,NumberExams,Status,StayNumberExams,StudentsNumber")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!memorizerId.Equals(oldMemorizerId))
                        await contextUserSession.DeleteUserSession(await contextUserSession.GetUserSession(oldMemorizerId, session.Id));

                    if (!supervisorId.Equals(oldSupervisorId))
                        await contextUserSession.DeleteUserSession(await contextUserSession.GetUserSession(oldSupervisorId, session.Id));

                    session.UserSessions.Add(await contextUserSession.CreateUserSession(memorizerId, session.Id));
                    session.UserSessions.Add(await contextUserSession.CreateUserSession(supervisorId, session.Id));
                    contextDB.ChangeTracker.Clear();
                    await context.UpdateSessionAsync(session);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SessionExists(session.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            var userMemorizer = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.محفظ);
            var userSupervisor = session.UserSessions.FirstOrDefault(x => x.user.TypeUser == TypeUser.مشرف);
            ViewData["userMemorizers"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.محفظ), "Id", "Name", userMemorizer.userId);
            ViewData["userSupervisors"] = new SelectList(userManager.Users.Where(x => x.TypeUser == TypeUser.مشرف), "Id", "Name", userSupervisor.userId);
            return View(session);
        }

        // GET: Sessions/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || (await context.GetAllSessionsAsync()) == null)
            {
                return NotFound();
            }

            var session = await context.GetSession((int)id);

            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if ((await context.GetAllSessionsAsync()) == null)
            {
                return Problem("Entity set 'tahfezKhalidContext.Session'  is null.");
            }

            var session = await context.GetSession(id);

            if (session != null && session.StudentsNumber == 0)
            {
                await context.DeleteSessionAsync(session);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        async Task<bool> SessionExists(int id)
        {
            return (await context.GetAllSessionsAsync()).Any(e => e.Id == id);
        }
    }
}