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
    public class OrderDetailDAO
    {
        HomeShoppeDBContext db = null;
        public OrderDetailDAO()
        {
            db = new HomeShoppeDBContext();
        }
        // hàm list trong admin
        public IEnumerable<OrderDetail> ListAll(int orderid, string searchString, int page, int pagesize)
        {
            var query = from a in db.OrderDetails
                        select a;
            if (orderid != 0)
            {
                query = query.Where(x => x.OrderID == orderid);
            }
            return query.OrderBy(x => x.ProductID).ToPagedList(page, pagesize);
        }

        //hàm trong website
        public List<OrderDetail> List(int orderID)
        {
            var query = from a in db.OrderDetails
                        select a;
            return query.Where(x => x.OrderID == orderID).OrderBy(x => x.ProductID).ToList();
        }
        
        //xử lý
        public bool Insert(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(OrderDetail entity)
        {
            var model = db.OrderDetails.Find(entity.OrderID);
            model.ProductID = entity.ProductID;
            model.Quantity = entity.Quantity;
            model.Price = entity.Price;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public OrderDetail GetByID(int ID)
        {
            return db.OrderDetails.SingleOrDefault(x => x.OrderID == ID);
        }
    }
}
