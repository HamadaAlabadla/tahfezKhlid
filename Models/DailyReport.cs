using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace tahfezKhalid.Models
{
    public class DailyReport
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الطالب مطلوب")]
        [Display(Name = "اسم الطالب")]

        public string studentId { get; set; }

       
        public Student student { get; set; }

        [Required(ErrorMessage = "الحفظ مطلوب")]
        [Display(Name = "الحفظ من")]
        public int SurahSavedFrom { get; set; }


        [Required(ErrorMessage = "الآية مطلوبة")]
        [Display(Name = "الأية من")]
        public int VerseSavedFrom { get; set; }


        [Required(ErrorMessage = "الحفظ مطلوب")]
        [Display(Name = "الحفظ إلى")]
        public int SurahSavedTo { get; set; }


        [Required(ErrorMessage = "الآية مطلوبة")]
        [Display(Name = "الأية إلى")]
        public int VerseSavedTo { get; set; }


        [Required(ErrorMessage = "عدد صفحات الحفظ مطلوبة")]
        [Display(Name = "عدد صفحات الحفظ")]
        public double NumPagesSaved { get; set; }


        [Required(ErrorMessage = "المراجعه مطلوبة")]
        [Display(Name = "المراجعه من")]
        public int SurahReviewFrom { get; set; }


        [Required(ErrorMessage = "الآية مطلوبة")]
        [Display(Name = "الأية من")]
        public int VerseReviewFrom { get; set; }

        [Required(ErrorMessage = "المراجعه مطلوبة")]
        [Display(Name = "المراجعه إلى")]
        public int SurahReviewTo { get; set; }


        [Required(ErrorMessage = "الآية مطلوبة")]
        [Display(Name = "الأية إلى")]
        public int VerseReviewTo { get; set; }


        [Required(ErrorMessage = "عدد صفحات المراجعه مطلوبة")]
        [Display(Name = "عدد صفحات المراجعه")]
        public double NumPagesReview { get; set; }
        public DateTime DateReport { get; set; }

        public bool View { get; set; } = false;
    }
}
