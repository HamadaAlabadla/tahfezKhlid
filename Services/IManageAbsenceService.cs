using Microsoft.EntityFrameworkCore;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageAbsenceService
    {
        Absence CreateAbsence(Absence absence);
        Absence GetAbsenceByDateAbsence(int studentId, DateTime dateAbsence);
    }
    public class ManageAbsenceService : IManageAbsenceService
    {
        readonly private tahfezKhalidContext _context;
        public ManageAbsenceService(tahfezKhalidContext context)
        {
            _context = context;
        }

        public Absence CreateAbsence(Absence absence)
        {
            var getAbsence = GetAbsenceByDateAbsence(absence.studentId, absence.dateAbsence);
            if (getAbsence != null)
                return getAbsence;
             _context.Add(absence);
             _context.SaveChanges();
            getAbsence = GetAbsenceByDateAbsence(absence.studentId, absence.dateAbsence);
            return getAbsence;
        }

        public Absence GetAbsenceByDateAbsence(int studentId, DateTime dateAbsence)
        {
            if (_context.Absences.Count() == 0)
                return null;
            var getAbsence = _context.Absences.FirstOrDefault(x => x.studentId == studentId 
            && x.dateAbsence.Year == dateAbsence.Year
            && x.dateAbsence.Month == dateAbsence.Month
            && x.dateAbsence.Day == dateAbsence.Day);
            return getAbsence;
        }

    }
}
