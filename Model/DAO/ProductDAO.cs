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
    public class ProductDAO
    {
        HomeShoppeDBContext db = null;
        public ProductDAO()
        {
            db = new HomeShoppeDBContext();
        }

        //hàm list danh sách sản phẩm trong admin

        public IEnumerable<Product> ListAll(string searchString, int page, int pagesize)
        {
            var query = from a in db.Products
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }
            return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public IEnumerable<Product> ListAllByCategoryID(int categoryid, string searchString, int page, int pagesize)
        {
            var query = from a in db.Products
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }
            if (categoryid != 0)
            {
                query = query.Where(x => x.CategoryID == categoryid || x.ProductCategory.ParentID == categoryid);
            }
           return query.OrderBy(x => x.ID).ToPagedList(page, pagesize);
            
        }

        //Hàm view sản phẩm trong website
        public List<Product> KhuyenMaiHot(int top)
        {
            return db.Products.Where(x => x.PromotionPrice != null).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> SanPhamNoiBat(int top)
        {
            return db.Products.Where(x => x.TopHot != null).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> XemNhieuNhat()
        {
            return db.Products.Where(x => x.ViewCount != null).OrderByDescending(x => x.ViewCount).Take(2).ToList();
        }
        public List<Product> SanPhamMoi(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> SanPhamCungLoai(int id)
        {
            var product = db.Products.Find(id);
            return db.Products.Where(x => x.ID != id && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreatedDate).Take(4).ToList();
        }
        //hàm lấy chi tiết sản phẩm
        public Product ViewProductDetail (int ID)
        {
            return db.Products.Find( ID);
        }
        //Lấy toàn bộ sản phẩm theo danh mục
        public List<Product> DanhSachSanPham(int categoryID, string sortby, string price, ref int totalRecord, int page, int pagesize)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID || x.ProductCategory.ParentID == categoryID).Count();
            var query = from a in db.Products
                        select a;
            if (!string.IsNullOrEmpty(sortby) || !string.IsNullOrEmpty(price))
            {
                if(sortby == "name-ASC")
                {
                    query = query.Where(x => x.CategoryID == categoryID || x.ProductCategory.ParentID == categoryID ).OrderBy(x => x.Name).Skip((page - 1) * pagesize).Take(pagesize);
                }
                if (sortby == "price-ASC")
                {
                    query = query.Where(x => x.CategoryID == categoryID || x.ProductCategory.ParentID == categoryID).OrderBy(x => x.Price).Skip((page - 1) * pagesize).Take(pagesize);
                }
                if (sortby == "price-DESC")
                {
                    query = query.Where(x => x.CategoryID == categoryID || x.ProductCategory.ParentID == categoryID).OrderByDescending(x => x.Price).Skip((page - 1) * pagesize).Take(pagesize);
                }
            }
            else
            {
                query = query.Where(x => x.CategoryID == categoryID || x.ProductCategory.ParentID == categoryID).OrderBy(x => x.ID).Skip((page - 1) * pagesize).Take(pagesize);
            }
            return query.ToList();
        }
        //Xử lý
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            var model = db.Products.Find(entity.ID);
            model.Name = entity.Name;
            model.Code = entity.Code;
            model.MetaTitle = entity.MetaTitle;
            model.Description = entity.Description;
            model.Image = entity.Image;
            model.Price = entity.Price;
            model.PromotionPrice = entity.PromotionPrice;
            model.Quantity = entity.Quantity;
            model.CategoryID = entity.CategoryID;
            model.Detail = entity.Detail;
            model.Warranty = entity.Warranty;
            model.TopHot = entity.TopHot;
            model.ViewCount = entity.ViewCount;
            model.Status = entity.Status;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Products.Find(id);
                db.Products.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Product GetByID(int ID)
        {
            return db.Products.SingleOrDefault(x => x.ID == ID);
        }
        public int ProductCount()
        {
            var result = db.Products.Count();
            return result;
        }


        //public IEnumerable<ProductViewModel> ListByCategoryID(int categoryid, string searchString, int page, int pagesize)
        //{
        //    var query = (from a in db.Products
        //                 join b in db.ProductCategories
        //                 on a.CategoryID equals b.ID
        //                 select new
        //                 {
        //                     ProductName = a.Name,
        //                     Code = a.Code,
        //                     MetaTitle = a.MetaTitle,
        //                     Description = a.Description,
        //                     Image = a.Image,
        //                     Price = a.Price,
        //                     PromotionPrice = a.PromotionPrice,
        //                     Quantity = a.Quantity,
        //                     Status = a.Status,
        //                     CategoryName = b.Name

        //                 }).AsEnumerable().Select(x => new ProductViewModel()
        //                 {
        //                     ProductName = x.ProductName,
        //                     Code = x.Code,
        //                     MetaTitle = x.MetaTitle,
        //                     Description = x.Description,
        //                     Image = x.Image,
        //                     Price = x.Price,
        //                     PromotionPrice = x.PromotionPrice,
        //                     Quantity = x.Quantity,
        //                     Status = x.Status,
        //                     ProductCategoryName = x.CategoryName
        //                 });
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        query = query.Where(x => x.ProductName.Contains(searchString) || x.Code.Contains(searchString) || x.ProductCategoryName.Contains(searchString));
        //    }
        //    query.OrderBy(x => x.ProductID).ToPagedList(page, pagesize);
        //    return query.ToList();
        //}
        //
    }
}
