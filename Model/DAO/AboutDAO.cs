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
    public class AboutDAO
    {
        HomeShoppeDBContext db = null;
        public AboutDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<About> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Abouts
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public List<About> List()
        {
            var query = from a in db.Abouts
                        select a;
          
            return query.ToList();
        }
        public bool Insert(About entity)
        {
            db.Abouts.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(About entity)
        {
            var model = db.Abouts.Find(entity.ID);
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.MetaTitle = entity.MetaTitle;
            model.Description = entity.Description;
            model.Image = entity.Image;
            model.Detail = entity.Detail;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Abouts.Find(id);
                db.Abouts.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public About GetAbout()
        {
            return db.Abouts.SingleOrDefault(x => x.Status == true);
        }
        public About GetByID(int ID)
        {
            return db.Abouts.SingleOrDefault(x => x.ID == ID);
        }
    }
}
