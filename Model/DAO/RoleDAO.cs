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
    public class RoleDAO
    {
        HomeShoppeDBContext db = null;
        public RoleDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<Role> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Roles
                         select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ID.Contains(searchString) || x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
            //var query = (from a in db.Roles
            //             select a).AsEnumerable().Select((a, i) => new {
            //                 Data = a,
            //                  i = 1,
            //                 Index = i + 1
            //                });
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    query = query.Where(x => x.Data.ID.Contains(searchString) || x.Data.Name.Contains(searchString));
            //}
            //return query.OrderBy(x => x.Data.ID).ToPagedList(page, pagesize);
        }
        public List<Role> List(string searchString)
        {
            var query = from a in db.Roles
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.ToList();
        }
        public bool Insert(Role entity)
        {
            db.Roles.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Role entity)
        {
            var model = db.Roles.Find(entity.ID);
            model.Name = entity.Name;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Roles.Find(id);
                db.Roles.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Role GetByID(string ID)
        {
            return db.Roles.SingleOrDefault(x => x.ID == ID);
        }
    }
}
