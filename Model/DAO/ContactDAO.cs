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
    public class ContactDAO
    {
        HomeShoppeDBContext db = null;
        public ContactDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public IEnumerable<Contact> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Contacts
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ID.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public List<Contact> List()
        {
            var query = from a in db.Contacts
                        select a;
            return query.ToList();
        }
        public bool Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Contact entity)
        {
            var model = db.Contacts.Find(entity.ID);
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
                var model = db.Contacts.Find(id);
                db.Contacts.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Contact GetContact()
        {
            return db.Contacts.SingleOrDefault(x => x.Status == true);
        }
        public Contact GetByID(string ID)
        {
            return db.Contacts.SingleOrDefault(x => x.ID == ID);
        }
    }
}
