using Microsoft.EntityFrameworkCore;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageDailyReportService
    {
        Task<DailyReport> CreateDailyReport(DailyReport dailyReport);
        Task<DailyReport> UpdateDailyReport(DailyReport dailyReport);
        Task<DailyReport> GetDailyReport(int dailyReportId, DateTime date);
        Task<DailyReport> GetLastDailyReportByStudentId(int studentId);
        Task<DailyReport> GetBeforLastDailyReportByStudentId(int studentId);
        Task<List<DailyReport>> GetAllDailyReports(Func<DailyReport,bool> fun = null);
    }

    public class ManageDailyReportService : IManageDailyReportService
    {
        private readonly tahfezKhalidContext _context;

        public ManageDailyReportService(tahfezKhalidContext context)
        {
            _context = context;
        }

        public async Task<DailyReport> CreateDailyReport(DailyReport dailyReport)
        {
            dailyReport.DateReport = DateTime.Now;
            await _context.AddAsync(dailyReport);
            await _context.SaveChangesAsync();
            var dailyReportNew = await GetLastDailyReportByStudentId(dailyReport.studentId);
            return dailyReportNew;
        }

        public async Task<List<DailyReport>> GetAllDailyReports(Func<DailyReport, bool> fun = null)
        {
            if (fun == null)
                return await _context.DailyReport.Include(x => x.student).ToListAsync();
            return _context.DailyReport.Include(x => x.student).Where(fun).ToList();
        }

        public async Task<DailyReport> GetBeforLastDailyReportByStudentId(int studentId)
        {
            var getDailyReports = await _context.DailyReport.Include(x => x.student).Where(x => x.studentId == studentId).ToListAsync();
            if (getDailyReports.Count() == 0)
                return null;
            else if(getDailyReports.Count() == 1)
                return getDailyReports.First();
            else
            {
                var getDailyReportBeforLast = getDailyReports.OrderBy(x => x.Id).Skip(getDailyReports.Count() - 2).FirstOrDefault();
                return getDailyReportBeforLast;
            }

        }

        public async Task<DailyReport> GetDailyReport(int dailyReportId, DateTime date)
        {
            var getDailyReport = await _context.DailyReport.FirstOrDefaultAsync(x => x.Id == dailyReportId ||( x.DateReport.Year == date.Year && x.DateReport.Month == date.Month && x.DateReport.Day == date.Day));
            return getDailyReport;
        }

        public async Task<DailyReport> GetLastDailyReportByStudentId(int studentId)
        {
            var reports = await GetAllDailyReports();
            if (reports.Count() == 0)
                return null;
            var getDailyReportLast = await _context.DailyReport.Include(x => x.student).OrderBy(x => x.Id).LastAsync(x => x.studentId == studentId);
            return getDailyReportLast; 
        }

        public async Task<DailyReport> UpdateDailyReport(DailyReport dailyReport)
        {
            var getDailyReport = await GetDailyReport(dailyReport.Id, dailyReport.DateReport);
            if (getDailyReport != null)
            {
                getDailyReport.SurahSavedTo = dailyReport.SurahSavedTo;
                getDailyReport.VerseSavedTo = dailyReport.VerseSavedTo;
                getDailyReport.SurahReviewTo = dailyReport.SurahReviewTo;
                getDailyReport.VerseReviewTo = dailyReport.SurahReviewTo;
                _context.Update(getDailyReport);
                await _context.SaveChangesAsync();
                return getDailyReport;
            }
            else
                return null;
        }
    }
}
