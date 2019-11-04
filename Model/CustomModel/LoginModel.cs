using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.CustomModel
{
   public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập vào tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập vào mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
