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
    public class OrderDAO
    {
        HomeShoppeDBContext db = null;
        public OrderDAO()
        {
            db = new HomeShoppeDBContext();
        }

        public IEnumerable<Order> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Orders
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ShipName.Contains(searchString));
            }
            return query.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }

        public Order ViewOrder(int ID)
        {
            return db.Orders.SingleOrDefault(x => x.ID == ID);
        }

        public Order ViewOrderByCustomerID(int ID)
        {
            return db.Orders.SingleOrDefault(x => x.CustomerID == ID);
        }

        //xử lý
        public long Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Order entity)
        {
            var model = db.Orders.Find(entity.ID);
            model.ShipName = entity.ShipName;
            model.ShipMobile = entity.ShipMobile;
            model.ShipEmail = entity.ShipEmail;
            model.ShipAddress = entity.ShipAddress;
            model.CreatedDate = entity.CreatedDate;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Orders.Find(id);
                db.Orders.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Order GetByID(int ID)
        {
            return db.Orders.SingleOrDefault(x => x.ID == ID);
        }
    }
}
