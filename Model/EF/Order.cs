namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? CustomerID { get; set; }

        [Display(Name = "Tên người nhận*")]
        [StringLength(50)]
        public string ShipName { get; set; }

        [Display(Name = "Số điện thoại*")]
        [StringLength(50)]
        public string ShipMobile { get; set; }

        [Display(Name = "Địa chỉ*")]
        [StringLength(50)]
        public string ShipAddress { get; set; }

        [Display(Name = "Email*")]
        [StringLength(50)]
        public string ShipEmail { get; set; }

        [Display(Name = "Tình trạng*")]
        public int? Status { get; set; }
		
        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
