using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Common
{
    [Serializable]
    public class LoginDetail
    {
        public User  User { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
    }
}
