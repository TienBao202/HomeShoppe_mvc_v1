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
    public class SlideDAO
    {
        HomeShoppeDBContext db = null;
        public SlideDAO()
        {
            db = new HomeShoppeDBContext();
        }
        //Hàm list trong Index
        public IEnumerable<Slide> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Slides
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.OrderBy(x => x.DisplayOrder).ToPagedList(page, pagesize);
        }

        // Hàm list trong website
        public List<Slide> List()
        {
            var query = from a in db.Slides
                        select a;
           
            return query.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }

        //Xử lý
        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Slide entity)
        {
            var model = db.Slides.Find(entity.ID);
            model.Name = entity.Name;
            model.Image = entity.Image;
            model.DisplayOrder = entity.DisplayOrder;
            model.Link = entity.Link;
            model.Description = entity.Description;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Slides.Find(id);
                db.Slides.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Slide GetByID(int ID)
        {
            return db.Slides.SingleOrDefault(x => x.ID == ID);
        }
    }
}
