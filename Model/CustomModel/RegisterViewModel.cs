using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CustomModel
{
    public class RegisterViewModel
    {
        [Key]
        public int ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]       
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(maximumLength: 10, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự!")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Bạn chưa xác nhận mật khẩu ")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Họ và tên")]
        public string FullName { set; get; }

        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }

        [Display(Name = "Email")]
       // [RegularExpression(@"")]
        public string Email { set; get; }

        [Display(Name = "Điện thoại")]
        public string Phone { set; get; }

    }
}
