using System.ComponentModel.DataAnnotations;

namespace tahfezKhalid.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم بالكامل مطلوب")]
        [Display(Name = "الإسم بالكامل")]
        [MinLength(10)]
        [MaxLength(35)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "مطلوب إدخال عدد الطلاب")]
        [Display(Name = "عدد الطلاب")]

        public int StudentsNumber { get; set; }
        [Display(Name = "تاريخ البدء")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "مطلوب إدخال عدد الصفحات المطلوبة شهريا")]
        [Display(Name = "عدد الصفحات شهريا")]
        public int NumberPages { get; set; }
        [Display(Name = "عدد الإختبارات السنوية")]
        public int NumberExams { get; set; }
        [Display(Name = "عدد الإختبارات المتبقية")]
        public int StayNumberExams { get; set; }
        [Required]
        [Display(Name = "الحالة")]
        public state Status { get; set; }

        public ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }

    public enum state
    {
        فعال = 0,
        غير_فعال = 1,
    }
}
