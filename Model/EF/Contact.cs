namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Display(Name = "Mã trang liên hệ*")]
        [StringLength(50)]
        public string ID { get; set; }
        [Display(Name = "Nội dung*")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        [Display(Name = "Tình trạng*")]
        public bool Status { get; set; }
    }
}
