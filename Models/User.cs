using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using tahfezKhalid.Models;

namespace tahfez.Models
{
    public class User : IdentityUser
    {
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

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Display(Name = "رقم الهاتف")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        override
        public string PhoneNumber
        { get; set; }

        // [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        // [Display(Name = "كلمة المرور")]
        // [DataType(DataType.Password)]
        // public string Password { get; set; }

        // [Required(ErrorMessage = "تأكيد كلمة المرور مطلوبة")]
        // [Display(Name = "تأكيد كلمة المرور")]
        // [Compare("Password")]
        // public string ConfirmPassword { get; set; }
        [Required]
        public TypeUser TypeUser { get; set; }

        public ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
        public ICollection<DeletedUser> DeletedUsers { get; set; } = new List<DeletedUser>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }

    public enum TypeUser
    {
        [Display(Name = "مدير  ")]
        آدمن = 0,
        [Display(Name = "محفظ  ")]
        محفظ = 1,
        [Display(Name = "ولي أمر  ")]
        ولي_أمر = 2,
        [Display(Name = "مشرف  ")]
        مشرف = 3
    }
}