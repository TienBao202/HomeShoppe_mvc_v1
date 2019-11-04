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
    public class MenuDAO
    {
        HomeShoppeDBContext db = null;
        public MenuDAO()
        {
            db = new HomeShoppeDBContext();
        }
        // hàm list trong admin
        public IEnumerable<Menu> ListAll(int menutypeID, string searchString, int page, int pagesize)
        {
            var query = from a in db.Menus
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Text.Contains(searchString));
            }
            if (menutypeID != 0)
            {
                query = query.Where(x => x.TypeID == menutypeID);
            }
            return query.OrderBy(x => x.DisplayOrder).ToPagedList(page, pagesize);
        }

        //hàm trong website
        public List<Menu> ListByMenuType( int menutype)
        {
            var query = from a in db.Menus
                        select a;
            return query.Where(x => x.TypeID == menutype && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        //xử lý
        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Menu entity)
        {
            var model = db.Menus.Find(entity.ID);
            model.Text = entity.Text;
            model.Link = entity.Link;
            model.Target = entity.Target;
            model.DisplayOrder = entity.DisplayOrder;
            model.TypeID = entity.TypeID;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Menus.Find(id);
                db.Menus.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Menu GetByID(int ID)
        {
            return db.Menus.SingleOrDefault(x => x.ID == ID);
        }
    }
}
