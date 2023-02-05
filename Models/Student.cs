using System.ComponentModel.DataAnnotations;
using tahfez.Models;

namespace tahfezKhalid.Models
{
    public class Student
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "الاسم بالكامل مطلوب")]
        [Display(Name = "الإسم بالكامل")]
        [MinLength(10)]
        [MaxLength(35)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "رقم الهوية مطلوب")]
        [Display(Name = "رقم الهوية")]
        [StringLength(9)]
        [RegularExpression("^[0-9]+$")]
        [DataType(DataType.PhoneNumber)]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "تاريخ الإضافة")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "صورة الطالب")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "الحلقة")]
        public int SessionId { get; set; }
        public Session Session { get; set; }
        [Display(Name = "ولي أمر الطالب")]
        [Required(ErrorMessage = "يرجى إدخال ولي أمر الطالب")]
        public string ParentId { get; set; }
        public User Parent { get; set; }
        [Display(Name = "السورة التي وصل إليها الطالب")]
        [Required(ErrorMessage = "يرجى إدخال السورة")]
        public int Surah { get; set; }

        [Display(Name = "الآية")]
        [Required]
        public int Verse { get; set; }

        [Display(Name = "آخر إختبار مجتمع")]
        [Required]
        public Exam FinalExam { get; set; }
        public ICollection<DailyReport> DailyReports { get; set; } = new List<DailyReport>();
    }

    public enum Exam
    {
        لم_يختبر,
        الناس_المجادلة,
        الناس_الأحقاف,
        الجاثية_يس,
        الجاثية_العنكبوت,
        الناس_العنكبوت,
        القصص_المؤمنون,
        القصص_مريم,
        الكهف_يوسف,
        الكهف_يونس,
        القصص_يونس,
        التوبة_الأعراف,
        التوبة_المائدة,
        النساء_آل_عمران,
        النساء_البقرة,
        التوبة_البقرة,
    }
}