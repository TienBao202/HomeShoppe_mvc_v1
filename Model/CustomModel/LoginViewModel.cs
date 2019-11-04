using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.CustomModel
{
    public class LoginViewModel
    {
        [Key]
        [Required(ErrorMessage = "Mời bạn nhập vào tài khoản")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập vào mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}
