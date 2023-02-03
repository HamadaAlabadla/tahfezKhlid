using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using tahfez.Models;
using tahfezKhalid.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        readonly IManageStudentService context;
        readonly IManageSessionService contextSession;
        readonly IManageUserSessionService _contextUserSession;
        readonly UserManager<User> userManager;

        public StudentsController(IManageStudentService context,
            IManageSessionService contextSession,
            UserManager<User> userManager,
            IManageUserSessionService contextUserSession)
        {
            this.context = context;
            this.contextSession = contextSession;
            this.userManager = userManager;
            _contextUserSession = contextUserSession;
        }
        [Authorize(Roles = "admin")]
        [Obsolete]

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah, "index", "titleAr");
            var tahfezKhalidContext = await context.GetAllStudents();
            return View(tahfezKhalidContext);
        }

        [Authorize(Roles = "admin,memorizer")]
        [Obsolete]

        // GET: Students
        public async Task<IActionResult> IndexStudent(int sessionId)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah, "index", "titleAr");
            var getSession = await contextSession.GetSession(sessionId);
            ViewData["sessionName"] = getSession.Name;
            ViewData["sessionId"] = getSession.Id;
            var tahfezKhalidContext = await context.GetAllStudentsBySessionId(sessionId);
            return View(tahfezKhalidContext);
        }

        public async Task<IActionResult> AddParentToSession(int sessionId)
        {
            ViewData["sessionId"] = sessionId;
            var parents = await userManager.Users
                .Include(x => x.UserSessions)
                .Include(x => x.DeletedUsers)
                .Where(x => x.TypeUser == TypeUser.ولي_أمر
                && x.DeletedUsers.Count() == 0)
                .ToListAsync();
            var parentsNew = new List<User>();
            foreach (var item in parents)
            {
                var getUserSession = await _contextUserSession.GetUserSession(item.Id, sessionId);
                if (getUserSession == null)
                    parentsNew.Add(item);
            }
            ViewData["parent"] = new SelectList( parentsNew, "Id","Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParentToSession(int sessionId,string parent)
        {
            var userSession = await _contextUserSession.CreateUserSession(parent, sessionId);
            return RedirectToAction(nameof(Create), new { Id = sessionId });
        }



        [Authorize(Roles = "admin,memorizer")]
        //// GET: Students/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Student == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Student
        //        .Include(s => s.Parent)
        //        .Include(s => s.Session)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}
        [Authorize(Roles = "admin,memorizer")]
        [Obsolete]
        // GET: Students/Create
        public async Task<IActionResult> Create(int Id)
        {
            if (Id == 0)
                return RedirectToAction("Welcome", "Home");

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah.OrderByDescending(x => x.index), "index", "titleAr");
            ViewData["surahCount"] = surah.OrderBy(x => x.index).ToList();
            var list = new List<Option<string>>();

            for (int i = 1; i < 7; i++)
            {
                var option = new Option<string>(i + "", i + "");
                list.Add(option);
            }

            ViewData["verse"] = new SelectList(list, "Feature", "Name");

            ViewData["exams"] = new SelectList(Enum.GetValues(typeof(Exam))
                .Cast<Exam>()
                .Select(x => x.ToString())
                .ToList(), "Id");
            ViewData["sessionId"] = Id;
            ViewData["ParentId"] = new SelectList(await contextSession.GetAllParentBySessionId(Id), "Id", "Name");
            ViewData["Session"] = new SelectList((await contextSession.GetAllSessionsAsync()).Where(x => x.Id == Id), "Id", "Name", Id);
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin,memorizer")]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Id,Name,Image,IdentificationNumber,DateOfBirth,DateAdded,SessionId,ParentId,Surah,Verse,FinalExam")] Student student)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            user = await userManager.Users.Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == user.Id);
            foreach (var item in user.UserSessions)
            {
                var session = await contextSession.GetSession(item.sessionId);
                item.session = session;
            }
            var check = true;

            if (user.TypeUser == TypeUser.محفظ)
            {
                var session = user.UserSessions.FirstOrDefault(x => x.sessionId == student.SessionId);

                if (session == null)
                    check = false;
            }

            if (check)
            {
                if (file != null)
                {
                    var fileName = file.FileName;
                    var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images/Students"));

                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        await file.CopyToAsync(fileStream);

                    student.Image = fileName;
                }
                student.DateAdded = DateTime.Now;
                if (ModelState.IsValid)
                {
                    await context.CreateStudent(student);
                    var session = await contextSession.GetSession(student.SessionId);
                    session.StudentsNumber += 1;
                    session.StayNumberExams += 2;
                    session.NumberExams += 2;
                    await contextSession.UpdateSessionAsync(session);
                    var parents = await contextSession.GetAllParentBySessionId(student.SessionId);
                    foreach (var parent in parents)
                    {
                        if(parent.Students.Count() == 0)
                        {
                            var userSession = await _contextUserSession.GetUserSession(parent.Id, student.SessionId);
                            await _contextUserSession.DeleteUserSession(userSession);
                        }
                        foreach (var item in parent.Students)
                        {
                            if((student.Session.Students.FirstOrDefault(x => x.Id == item.Id)) == null)
                            {
                                var userSession = await _contextUserSession.GetUserSession(parent.Id,student.SessionId);
                                await _contextUserSession.DeleteUserSession(userSession);
                            }
                        }
                    }
                    return RedirectToAction(nameof(IndexStudent), new { sessionId = student.SessionId });
                }
            }
            else
            {
                return RedirectToAction("Welcome","Home");
            }

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah, "index", "titleAr");
            ViewData["surahCount"] = surah.OrderBy(x => x.index).ToList();
            var list = new List<Option<string>>();

            for (int i = 1; i < 8; i++)
            {
                var option = new Option<string>(i + "", i + "");
                list.Add(option);
            }

            ViewData["verse"] = new SelectList(list, "Feature", "Name");

            ViewData["exams"] = new SelectList(Enum.GetValues(typeof(Exam))
                .Cast<Exam>()
                .Select(x => x.ToString())
                .ToList(), "Id");

            ViewData["ParentId"] = new SelectList(await contextSession.GetAllParentBySessionId(student.SessionId), "Id", "Name");
            ViewData["SessionId"] = new SelectList((await contextSession.GetAllSessionsAsync()).Where(x => x.Id == student.SessionId), "Id", "Name", student.SessionId);
            return View(student);
        }

        [Authorize(Roles = "admin,memorizer")]
        [Obsolete]

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || (await context.GetAllStudents()) == null)
            {
                return NotFound();
            }

            var student = await context.GetStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah, "index", "titleAr");
            ViewData["surahCount"] = surah.OrderBy(x => x.index).ToList();
            var list = new List<Option<string>>();

            for (int i = 1; i < 8; i++)
            {
                var option = new Option<string>(i + "", i + "");
                list.Add(option);
            }

            ViewData["verse"] = new SelectList(list, "Feature", "Name");

            ViewData["exams"] = new SelectList(Enum.GetValues(typeof(Exam))
                .Cast<Exam>()
                .Select(x => x.ToString())
                .ToList(), "Id");
            ViewData["sessionId"] = student.SessionId;
            ViewData["ParentId"] = new SelectList(await contextSession.GetAllParentBySessionId(student.SessionId), "Id", "Name");
            ViewData["Session"] = new SelectList((await contextSession.GetAllSessionsAsync()).Where(x => x.Id == student.SessionId), "Id", "Name", student.SessionId);
            return View(student);
        }

        [Authorize(Roles = "admin,memorizer")]
        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Edit(int id, IFormFile file, [Bind("Id,Name,IdentificationNumber,DateOfBirth,DateAdded,Image,SessionId,ParentId,Surah,Verse,FinalExam")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.GetUserAsync(HttpContext.User);
                    user = await userManager.Users.Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == user.Id);
                    var check = true;

                    if (user.TypeUser == TypeUser.محفظ)
                    {
                        var session = user.UserSessions.FirstOrDefault(x => x.sessionId == student.SessionId);

                        if (session == null)
                            check = false;
                    }

                    if (check)
                    {
                        if (file != null)
                        {
                            var fileName = file.FileName;
                            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images/Students"));

                            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                                await file.CopyToAsync(fileStream);

                            student.Image = fileName;
                        }

                        await context.UpdateStudent(student);
                    }
                    else
                    {
                        ModelState.AddModelError("", "الحلقة ليست من حلقاتك");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(IndexStudent),new { sessionId = student.SessionId });
            }

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

            ViewData["surah"] = new SelectList(surah, "index", "titleAr");
            ViewData["surahCount"] = surah.OrderBy(x => x.index).ToList();
            var list = new List<Option<string>>();

            for (int i = 1; i < 8; i++)
            {
                var option = new Option<string>(i + "", i + "");
                list.Add(option);
            }

            ViewData["verse"] = new SelectList(list, "Feature", "Name");

            ViewData["exams"] = new SelectList(Enum.GetValues(typeof(Exam))
                .Cast<Exam>()
                .Select(x => x.ToString())
                .ToList(), "Id");

            ViewData["ParentId"] = new SelectList(await contextSession.GetAllParentBySessionId(student.SessionId), "Id", "Name", "-1");
            ViewData["SessionId"] = new SelectList((await contextSession.GetAllSessionsAsync()).Where(x => x.Id == student.SessionId), "Id", "Name", student.SessionId);
            return View(student);
        }

        [Authorize(Roles = "admin,memorizer")]
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || (await context.GetAllStudents()) == null)
            {
                return NotFound();
            }

            var student = await context.GetStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [Authorize(Roles = "admin,memorizer")]
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,int SessionId)
        {
            if ((await context.GetAllStudents()) == null)
            {
                return Problem("Entity set 'tahfezKhalidContext.Student'  is null.");
            }

            await context.DeleteStudent(id);

            return RedirectToAction(nameof(IndexStudent),new { sessionId = SessionId });
        }

        [Authorize(Roles = "admin,memorizer")]
        async Task<bool> StudentExists(int id)
        {
            return (await context.GetAllStudents()).Any(e => e.Id == id);
        }
    }
}