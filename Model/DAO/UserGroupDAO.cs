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
    public class UserGroupDAO
    {
        HomeShoppeDBContext db = null;
        public UserGroupDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<UserGroup> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.UserGroups
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ID.Contains(searchString) || x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public IEnumerable<UserGroup> List()
        {
            var query = from a in db.UserGroups
                        select a;
            
            return query.OrderBy(x => x.ID).ToList();
        }
        public bool Insert(UserGroup entity)
        {
            db.UserGroups.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(UserGroup entity)
        {
            var model = db.UserGroups.Find(entity.ID);
            model.Name = entity.Name;
            db.SaveChanges();
            return true;
        }
        public bool Delete(string id)
        {
            try
            {
                var model = db.UserGroups.Find(id);
                db.UserGroups.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public UserGroup GetByID(string ID)
        {
            return db.UserGroups.SingleOrDefault(x => x.ID == ID);
        }
    }
}
