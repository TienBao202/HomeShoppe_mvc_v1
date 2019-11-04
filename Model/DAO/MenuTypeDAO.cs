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
    public class MenuTypeDAO
    {
        HomeShoppeDBContext db = null;
        public MenuTypeDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<MenuType> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.MenuTypes
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public List<MenuType> List()
        {
            var query = from a in db.MenuTypes
                        select a;
            
            return query.ToList();
        }
        public int Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(MenuType entity)
        {
            var model = db.MenuTypes.Find(entity.ID);
            model.Name = entity.Name;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public MenuType GetByID(int ID)
        {
            return db.MenuTypes.SingleOrDefault(x => x.ID == ID);
        }
    }
}
