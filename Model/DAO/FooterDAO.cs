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
    public class FooterDAO
    {
        HomeShoppeDBContext db = null;
        public FooterDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<Footer> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Footers
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ID.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public List<Footer> List()
        {
            var query = from a in db.Footers
                        select a;
            return query.ToList();
        }
        public bool Insert(Footer entity)
        {
            db.Footers.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Footer entity)
        {
            var model = db.Footers.Find(entity.ID);
            model.ID = entity.ID;
            model.Content = entity.Content;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(string id)
        {
            try
            {
                var model = db.Footers.Find(id);
                db.Footers.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
        public Footer GetByID(string ID)
        {
            return db.Footers.SingleOrDefault(x => x.ID == ID);
        }
    }
}
