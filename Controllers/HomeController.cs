using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tahfez.Models;
using tahfezKhalid.Services;
using tahfezKhlid.Models;

namespace tahfezKhlid.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly UserManager<User> userManager;
        readonly ILogger<HomeController> logger;
        readonly IManageDeleteUserService contextDelete;
        readonly IManageSessionService contextSession;

        public HomeController(ILogger<HomeController> logger,
            UserManager<User> userManager,
            IManageDeleteUserService contextDelete,
            IManageSessionService contextSession)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.contextDelete = contextDelete;
            this.contextSession = contextSession;
        }

        public async Task<IActionResult> Welcome()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            user = await userManager.Users.Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == user.Id);
            ViewData["Name"] = user.Name;
            ViewData["Type"] = user.TypeUser.ToString();

            foreach (var item in user.UserSessions)
            {
                var session = await contextSession.GetSession(item.sessionId);
                item.session = session;
            }

            if (user.TypeUser == TypeUser.محفظ)
            {
                var sessions = user.UserSessions.Select(x => x.session).ToList();

                //if (sessions.Count == 1)
                //{
                //    return RedirectToAction("IndexStudent", "Students",new { sessionId = sessions.First().Id });
                //}

                ViewData["sessions"] = sessions;
            }

            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string userId, int typeId)
        {
            await contextDelete.DeleteUserAsync(userId);
            return RedirectToAction(nameof(Index), new { Id = typeId });
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddUser(string userId, int typeId)
        {
            await contextDelete.AddUserAsync(userId);
            return RedirectToAction(nameof(Index), new { Id = typeId });
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(int Id)
        {
            ViewData["Type"] = ((TypeUser)Id).ToString();
            ViewData["Id"] = Id;
            var users = await userManager.Users.Include(x => x.DeletedUsers).Where(x => x.TypeUser == ((TypeUser)Id)).ToListAsync();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}