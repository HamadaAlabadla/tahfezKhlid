using Microsoft.EntityFrameworkCore;
using tahfezKhalid.Data;
using tahfezKhalid.Models;

namespace tahfezKhalid.Services
{
    public interface IManageStudentService
    {
        Task<Student> GetStudent(int studentId);
        Task<List<Student>> GetAllStudents();
        Task<List<Student>> GetAllStudentsBySessionId(int sessionId);
        Task<List<Student>> GetAllStudentsByParentId(string parentId);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int studentId);

    }

    public class ManageStudentService : IManageStudentService
    {
        readonly tahfezKhalidContext context;

        public ManageStudentService(tahfezKhalidContext context) => this.context = context;

        public async Task<Student> CreateStudent(Student student)
        {
            var getStudent = await context.Students.FirstOrDefaultAsync(x => x.IdentificationNumber == student.IdentificationNumber);

            if (getStudent != null)
                throw new Exception("الطالب موجود مسبقا");
            student.DateAdded = DateTime.Now;
            await context.AddAsync(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int studentId)
        {
            var getStudent = await GetStudent(studentId);

            if (getStudent == null)
                throw new Exception("الطالب غير موجود");

            context.Remove(getStudent);
            await context.SaveChangesAsync();
            return getStudent;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var getStudents = await context.Students.Include(x => x.Session).Include(x => x.Parent).ToListAsync();
            return getStudents;
        }

        public async Task<List<Student>> GetAllStudentsByParentId(string parentId)
        {
            var getStudents = await context.Students.Include(x => x.Session).Include(x => x.Parent).Where(x => x.ParentId == parentId).ToListAsync();
            return getStudents;
        }

        public async Task<List<Student>> GetAllStudentsBySessionId(int sessionId)
        {
            var getStudents = await context.Students.Include(x => x.Session).Include(x => x.Parent).Where(x => x.SessionId == sessionId).ToListAsync();
            return getStudents;
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var getStudent = await context.Students.Include(x => x.Session).Include(x => x.Parent).FirstOrDefaultAsync(x => x.Id == studentId);
            return getStudent;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var getStudent = await GetStudent(student.Id);

            if (getStudent == null)
                throw new Exception("الطالب غير موجود");

            getStudent.Name = student.Name;
            getStudent.Image = student.Image;
            context.Update(getStudent);
            await context.SaveChangesAsync();
            return getStudent;
        }
    }
}