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
    public class FeedbackDAO
    {
        HomeShoppeDBContext db = null;
        public FeedbackDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<Feedback> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Feedbacks
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.ToPagedList(page, pagesize);
        }
        public List<Feedback> List(string searchString)
        {
            var query = from a in db.Feedbacks
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            return query.ToList();
        }
        public bool Insert(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Feedback entity)
        {
            var model = db.Feedbacks.Find(entity.ID);
            model.Name = entity.Name;
            model.Phone = entity.Phone;
            model.Email = entity.Email;
            model.Address = entity.Address;
            model.Content = entity.Content;
            model.CreatedDate = entity.CreatedDate;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Feedback GetByID(int ID)
        {
            return db.Feedbacks.SingleOrDefault(x => x.ID == ID);
        }
    }
}
