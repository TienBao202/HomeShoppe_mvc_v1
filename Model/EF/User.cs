namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [Display(Name = "Tài khoản*")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu*")]
        [StringLength(32)]
        public string Password { get; set; }

        [Display(Name = "Loại thành viên*")]
        [StringLength(20)]
        public string GroupID { get; set; }

        [Display(Name = "Họ và tên*")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Ngày sinh*")]
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(50)]
        public string Gender { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Email*")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Tình trạng*")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
