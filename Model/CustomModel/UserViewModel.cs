using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.CustomModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập vào tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập vào mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập vào quyền hạn")]
        public string UserGroupID { get; set; }
        public string UserGroupName { get; set; }
        public string FullName { get; set; }

        
        public DateTime? Birthday { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Status { get; set; }
    }
}
