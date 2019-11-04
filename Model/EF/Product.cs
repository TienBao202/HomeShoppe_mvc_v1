namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn không được để trống mục này!")]
        [Display(Name = "Tên sản phẩm*")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Mã sản phẩm*")]
        [StringLength(10)]
        public string Code { get; set; }

        [Display(Name = "Tên meta")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả*")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Hình ảnh*")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Hình ảnh chi tiết")]
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Display(Name = "Giá gốc*")]
        public decimal? Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "Số lượng*")]
        public int Quantity { get; set; }

        [Display(Name = "Danh mục sản phẩm*")]
        public int? CategoryID { get; set; }

        [Display(Name = "Thông số chi tiết*")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Display(Name = "Bảo hành")]
        public int? Warranty { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Tình trạng*")]
        public bool Status { get; set; }

        [Display(Name = "Ngày bán*")]
        public DateTime? TopHot { get; set; }

        [Display(Name = "Lượt xem*")]
        public int? ViewCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
