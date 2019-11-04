namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [Display(Name = "Tên slide *")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Hình ảnh *")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Tệp hình ảnh *")]
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Display(Name = "Thứ tự hiển thị *")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Đường dẫn *")]
        [StringLength(250)]
        public string Link { get; set; }

        [Display(Name = "Mô tả *")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Display(Name = "Ngày tạo *")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Người tạo *")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Display(Name = "Tình trạng *")]
        public bool Status { get; set; }
    }
}
