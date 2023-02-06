using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using tahfez.Models;
using tahfezKhalid.Data;
using tahfezKhalid.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Controllers
{
    public class DailyReportsController : Controller
    {
        private readonly IManageStudentService _contextStudent;
        private readonly IManageSessionService _contextSession;
        private readonly UserManager<User> userManager;
        private readonly IManageDailyReportService _context;
        private readonly IManageAbsenceService _contextAbsence;

        public DailyReportsController(IManageDailyReportService context,
            IManageStudentService contextStudent,
            IManageSessionService contextSession,
            UserManager<User> userManager,
            IManageAbsenceService contextAbsence)
        {
            this.userManager = userManager;
            _context = context;
            _contextStudent = contextStudent;
            _contextSession = contextSession;
            _contextAbsence = contextAbsence;
        }

        // GET: DailyReports
        public async Task<IActionResult> Index(int sessionId = -1 , int Year = -1, int month = -1)
        {
            if (Year == -1)
                Year = DateTime.Now.Year;
            if (month == -1)
                month = DateTime.Now.Month;
            ViewData["year"] = Year;
            ViewData["month"] = month;
            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);
            ViewData["ListSurah"] = surah;
            var session = await _contextSession.GetSession(sessionId);
            if (sessionId == -1)
            {
                ViewData["Absence"] = await _contextAbsence.GetAllAbsenceList(x => x.dateAbsence.Year == Year && x.dateAbsence.Month == month);
                return View(await _context.GetAllDailyReports(x => x.DateReport.Year == Year && x.DateReport.Month == month));
            }
            else
            {
                ViewData["Absence"] = await _contextAbsence.GetAllAbsenceList(x =>x.student.SessionId == sessionId&& x.dateAbsence.Year == Year && x.dateAbsence.Month == month);
                ViewData["sessionName"] = session.Name;
                ViewData["sessionId"] = session.Id;
                return View(await _context.GetAllDailyReports(x => x.student.SessionId == sessionId && x.DateReport.Year == Year && x.DateReport.Month == month));
            }
        }

        // GET: DailyReports/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null ||(await _context.GetAllDailyReports()) == null)
        //    {
        //        return NotFound();
        //    }

        //    var dailyReport = await _context.GetDailyReport((int)id);
        //    if (dailyReport == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dailyReport);
        //}

        // GET: DailyReports/Create
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        [HttpGet]
        public async Task<IActionResult> Create(int sessionId)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var user = await userManager.Users.Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Id == userId);
            if (user.UserSessions.FirstOrDefault(x => x.sessionId == sessionId) != null)
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString("wwwroot/Quran.json");
                var surah = JsonConvert.DeserializeObject<List<Surah>>(json);

                var session = await _contextSession.GetSession(sessionId);
                var reports = new ListDailyReport()
                {
                    ReportItems = new List<DailyReport>(),
                };
                foreach (var item in session.Students)
                {
                    var lastReport = await _context.GetLastDailyReportByStudentId(item.Id);
                    var BeforlastReport = await _context.GetBeforLastDailyReportByStudentId(item.Id);

                    var surahSaveNum = (lastReport != null) ? lastReport.SurahSavedTo : item.Surah;
                    var surahReviewNum = (BeforlastReport != null) ? BeforlastReport.SurahSavedFrom : item.Surah;

                    var versSaveNum = (lastReport != null) ? lastReport.VerseSavedTo : item.Verse;
                    var versReviewNum = (BeforlastReport != null) ? BeforlastReport.VerseSavedFrom : item.Verse;
                    if (versSaveNum == surah.FirstOrDefault(x => x.index == surahSaveNum).count)
                    {
                        versSaveNum = 1;
                        surahSaveNum--;
                    }
                    else
                    {
                        versSaveNum++;
                        versReviewNum++;
                    }


                    reports.ReportItems.Add(new DailyReport
                    {
                        studentId = item.Id,
                        student = item,
                        SurahSavedFrom = surahSaveNum,
                        VerseSavedFrom = versSaveNum,
                        SurahReviewFrom = surahReviewNum,
                        VerseReviewFrom = versReviewNum,
                    });
                }
                ViewData["ListSurah"] = surah;
                ViewData["sessionName"] = session.Name;
                return View(reports);
            }
            else
            {
                return RedirectToAction("Welcome","Home");
            }
        }

        // POST: DailyReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<int> Absence,List<string> reason, ListDailyReport listDailyReport)
        {
            if (ModelState.IsValid)
            {
                var i = 0;
                foreach (var dailyReport in listDailyReport.ReportItems)
                {
                    if (Absence[i] ==0)
                        await _context.CreateDailyReport(dailyReport);
                    else if (Absence[i] <= 3)
                    {
                        var abs = new Absence()
                        {
                            dateAbsence = DateTime.Now,
                            studentId = dailyReport.studentId,
                            TypeAbsence = (typeAbsence)Absence[i],
                            reason = ""
                        };
                        if (Absence[i] == 1)
                            abs.reason = reason[i];

                        _contextAbsence.CreateAbsence(abs);
                    }
                    i++;
                }
                var student = await _contextStudent.GetStudent(listDailyReport.ReportItems.FirstOrDefault().studentId);
                var sessionId = -1;
                if (student != null)
                    sessionId = student.SessionId;

                return RedirectToAction(nameof(Index),new { sessionId = sessionId, Year = DateTime.Now.Year, month = DateTime.Now.Month });
            }

            return View(listDailyReport);
        }

        // GET: DailyReports/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.DailyReport == null)
        //    {
        //        return NotFound();
        //    }

        //    var dailyReport = await _context.DailyReport.FindAsync(id);
        //    if (dailyReport == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdentificationNumber"] = new SelectList(_context.Students, "IdentificationNumber", "IdentificationNumber", dailyReport.IdentificationNumber);
        //    return View(dailyReport);
        //}

        // POST: DailyReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,studentId,IdentificationNumber,SurahSavedFrom,VerseSavedFrom,SurahSavedTo,VerseSavedTo,NumPagesSaved,SurahReviewFrom,VerseReviewFrom,SurahReviewTo,VerseReviewTo,NumPagesReview,DateReport")] DailyReport dailyReport)
        //{
        //    if (id != dailyReport.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(dailyReport);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DailyReportExists(dailyReport.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentificationNumber"] = new SelectList(_context.Students, "IdentificationNumber", "IdentificationNumber", dailyReport.IdentificationNumber);
        //    return View(dailyReport);
        //}

        // GET: DailyReports/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.DailyReport == null)
        //    {
        //        return NotFound();
        //    }

        //    var dailyReport = await _context.DailyReport
        //        .Include(d => d.student)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (dailyReport == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dailyReport);
        //}

        // POST: DailyReports/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.DailyReport == null)
        //    {
        //        return Problem("Entity set 'tahfezKhalidContext.DailyReport'  is null.");
        //    }
        //    var dailyReport = await _context.DailyReport.FindAsync(id);
        //    if (dailyReport != null)
        //    {
        //        _context.DailyReport.Remove(dailyReport);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DailyReportExists(int id)
        //{
        //  return _context.DailyReport.Any(e => e.Id == id);
        //}
    }
}
