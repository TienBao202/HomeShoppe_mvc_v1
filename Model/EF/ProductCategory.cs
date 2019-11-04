namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        [Display(Name = "Mã danh mục*")]
        public int ID { get; set; }

        [Display(Name = "Tên danh mục*")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Tên Meta*")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Danh mục cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

        [Display(Name = "Cho phép hiển thị")]
        public bool ShowOnHome { get; set; }

		[Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string image { get; set; }

		[Display(Name = "Biểu tượng*")]
        [StringLength(50)]
        public string icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
