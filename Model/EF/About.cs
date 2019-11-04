namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int ID { get; set; }

        [Display(Name = "Tên trang *")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Tên Meta*")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả*")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Hình ảnh*")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Chi tiết*")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Tình trạng*")]
        public bool Status { get; set; }
    }
}
