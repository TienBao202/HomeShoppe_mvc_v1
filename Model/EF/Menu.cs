namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Display(Name = "Mã menu*")]
        public int ID { get; set; }

        [Display(Name = "Tên menu*")]
        [StringLength(50)]
        public string Text { get; set; }

        [Display(Name = "Đường dẫn*")]
        [StringLength(250)]
        public string Link { get; set; }

        [Display(Name = "Thứ tự hiển thị*")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Kiểu hiển thị*")]
        [StringLength(50)]
        public string Target { get; set; }

        [Display(Name = "Tình trạng*")]
        public bool Status { get; set; }

        [Display(Name = "Loại menu*")]
        public int? TypeID { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
