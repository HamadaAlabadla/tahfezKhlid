using System.ComponentModel.DataAnnotations;

namespace tahfezKhalid.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string studentId { get; set; }
        public Student student { get; set; }
        public DateTime dateAbsence { get; set; }
        [Display(Name ="الحالة")]
        public typeAbsence TypeAbsence { get; set; }
        [MaxLength(50)]
        public string reason { get; set; }

    }

    public enum typeAbsence
    {
        غياب_بإذن =1,
        غياب_بدون_إذن =2,
        غياب_المحفظ =3,
    }
}

