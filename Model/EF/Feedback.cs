namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int ID { get; set; }

        [Display(Name = "Họ tên*")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Điện thoại*")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Email*")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ*")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Nội dung*")]
        [StringLength(250)]
        public string Content { get; set; }

        [Display(Name = "Ngày gửi")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Tình trạng*")]
        public bool? Status { get; set; }
    }
}
