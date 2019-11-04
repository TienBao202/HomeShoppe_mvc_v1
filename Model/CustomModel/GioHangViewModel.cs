using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CustomModel
{
    [Serializable]
   public class GioHangViewModel
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        private decimal? dongia { get; set; }

        public decimal? ThanhTien
        {
            get
            {
                if(Product.PromotionPrice != null)
                {
                     dongia = Product.PromotionPrice;
                   
                }
                else
                {
                     dongia = Product.Price;
                }
                return Quantity * dongia ;
            }
        }
    }
}
