using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CustomModel
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Code { get; set; }

        public string MetaTitle { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string MoreImages { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        public int? ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }

        public string DescroptionDetail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        public bool? Status { get; set; }
    }
}
