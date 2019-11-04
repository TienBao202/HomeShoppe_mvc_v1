using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.CustomModel;

namespace Model.DAO
{
   public class UserDAO
   {
        HomeShoppeDBContext db = null;
        public UserDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<User> ListAll( string usergroupid, string searchString, ref int totalRecord, int page , int pagesize)
        {
            totalRecord = db.Users.Count();
            var query = from u in db.Users
                        select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(usergroupid))
            {
                query = query.Where(x => x.GroupID == usergroupid);
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
            //return query.OrderBy(x => x.ID).Skip((page - 1) * pagesize).Take(pagesize);
        }
        public IEnumerable<User> ListAllByCategory(string searchString, int page, int pagesize)
        {
            var query = from a in db.Users
                        join b in db.UserGroups
                        on a.GroupID equals b.ID
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        //public IEnumerable<UserViewModel> List(string searchString, int page, int pagesize)
        //{

        //    var query = (from u in db.Users
        //                 join g in db.UserGroups
        //                 on u.UserGroupID equals g.UserGroupID
        //                 select new
        //                 {
        //                     UserID = u.UserID,
        //                     UserName = u.UserName,
        //                     Password = u.Password,
        //                     FullName = u.FullName,
        //                     Birthday = u.Birthday,
        //                     Gender = u.Gender,
        //                     Address = u.Address,
        //                     Email = u.Email,
        //                     Phone = u.Phone,
        //                     CreatedDate = u.CreatedDate,
        //                     Status = u.Status,
        //                     UserGroupID = u.UserGroupID,
        //                     UserGroupName = g.Name

        //                 }).AsEnumerable().Select(x => new UserViewModel()
        //                 {

        //                     UserID = x.UserID,
        //                     UserName = x.UserName,
        //                     Password = x.Password,
        //                     FullName = x.FullName,
        //                     Birthday = x.Birthday,
        //                     Gender = x.Gender,
        //                     Address = x.Address,
        //                     Email = x.Email,
        //                     Phone = x.Phone,
        //                     Status = x.Status,
        //                     UserGroupID = x.UserGroupID,
        //                     UserGroupName = x.UserGroupName
        //                 });
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        query = query.Where(x => x.UserName.Contains(searchString) || x.FullName.Contains(searchString));
        //    }
        //    query.OrderBy(x => x.UserID).ToPagedList(page, pagesize);
        //    return query.ToList();
        //}

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            var model = db.Users.Find(entity.ID);
            model.Name = entity.Name;
            model.Password = entity.Password;
            model.Birthday = entity.Birthday;
            model.Gender = entity.Gender;
            model.Address = entity.Address;
            model.Email = entity.Email;
            model.Phone = entity.Phone;
            model.GroupID = entity.GroupID;
            model.CreatedDate = entity.CreatedDate;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Users.Find(id);
                db.Users.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int Login(string taikhoan, string matkhau)
        {

            var res = db.Users.SingleOrDefault(x => x.UserName == taikhoan);
            if (res == null)
                return 0; //Tài khoản không tồn tại
            else
            {
                if (res.Status == false)
                    return -1; //Tài khoản bị khóa
                else
                {
                    if (res.Password == matkhau)
                    {
                        return 1; //Đăng nhập thành công
                    }
                    else
                    {
                        return 2; //Mật khẩu không chính xác
                    }

                }
            }

        }
        public User KiemTraDangNhap(string taikhoan)
        {
            return db.Users.SingleOrDefault(x => x.UserName == taikhoan);
        }
        public User GetByID(int ID)
        {
            return db.Users.SingleOrDefault(x => x.ID == ID);
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }

        // Thống kê số lượng
        public int Usercount()
        {
            return db.Users.Count();
        }
        public int UsercountAdmin()
        {
            return db.Users.Count(x => x.GroupID == "ADMIN");
        }
        public int UsercountEmpployee()
        {
            return db.Users.Count(x => x.GroupID == "Empployee");
        }
        public int UsercountMember()
        {
            return db.Users.Count(x => x.GroupID == "MEMBER");
        }
    }
}
