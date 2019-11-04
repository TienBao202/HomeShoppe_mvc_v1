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
    public class ProductCategoryDAO
    {
        HomeShoppeDBContext db = null;
        public ProductCategoryDAO()
        {
            db = new HomeShoppeDBContext();
        }
        /// <summary>
        /// Load tất cả danh mục
        /// </summary>
        /// <param name="Parentcategoryid"></param>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public IEnumerable<ProductCategory> ListAll(int Parentcategoryid, string searchString, int page, int pagesize)
        {
            var query = from a in db.ProductCategories
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString));
            }
            if (Parentcategoryid != 0)
            {
                query = query.Where(x => x.ParentID == Parentcategoryid);
            }
            return query.OrderBy(x => x.ParentID).ToPagedList(page, pagesize);
        }

        /// <summary>
        /// Load danh mục cha
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> ListParentCategory()
        {
            var query = from a in db.ProductCategories
                        where a.ParentID == null
                        select a;
            return query.ToList();
        }

        /// <summary>
        /// Load danh mục con
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> ListChildCategory(int parentid)
        {
            var query = from a in db.ProductCategories
                        where a.ParentID == parentid
                        select a;
            return query.OrderByDescending(x => x.DisplayOrder).ToList();
        }

        /// <summary>
        /// Tạo Dropdownlist đa cấp 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductCategory> GetCategoriesSelectList()
        {
            var categories = db.ProductCategories.ToList();
            // Initialise list and add first "All" item
            List<ProductCategory> options = new List<ProductCategory>
            {
                new ProductCategory(){ ID = 0, Name = "Tất cả" }
            };
            // Get the top level parents
            var parents = categories.Where(x => x.ParentID == null);
            foreach (var parent in parents)
            {
                // Add SelectListItem for the parent
                options.Add(new ProductCategory()
                {
                    ID = parent.ID,
                    Name = parent.Name
                });
                // Get the child items associated with the parent
                var children = categories.Where(x => x.ParentID == parent.ID);
                // Add SelectListItem for each child
                foreach (var child in children)
                {
                    options.Add(new ProductCategory()
                    {
                        ID = child.ID,
                        Name = string.Format("-- {0}", child.Name)
                    });
                }
            }
            return options;
        }

        /// <summary>
        /// Load danh mục hiển thị trên website
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> ViewCategory()
        {
            var query = from a in db.ProductCategories
                        select a;
            return query.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }

        /// <summary>
        /// Load danh mục nổi bật
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<ProductCategory> Danhmucnoibat(int top)
        {
            return db.ProductCategories.Where(x => x.ParentID == null).OrderByDescending(x => x.DisplayOrder).Take(top).ToList();
        }

        /// <summary>
        /// Load thông tin chi tiết của danh mục
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ProductCategory ViewCategoryDetail(int ID)
        {
            return db.ProductCategories.Find(ID);
        }

        /// <summary>
        /// Các hàm xử lý
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(ProductCategory entity)
        {
            var model = db.ProductCategories.Find(entity.ID);
            model.Name = entity.Name;
            model.MetaTitle = entity.MetaTitle;
            model.ParentID = entity.ParentID;
            model.DisplayOrder = entity.DisplayOrder;
            model.ShowOnHome = entity.ShowOnHome;
            model.Status = entity.Status;
            model.image = entity.image;
            model.icon = entity.icon;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ProductCategory GetByID(int ID)
        {
            return db.ProductCategories.SingleOrDefault(x => x.ID == ID);
        }

    }
}
