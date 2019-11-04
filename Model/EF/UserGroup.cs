namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserGroup")]
    public partial class UserGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserGroup()
        {
            Users = new HashSet<User>();
        }
        [Required(ErrorMessage = "Mã loại thành viên không được để trống")]
        [Display(Name = "Mã loại thành viên*")]
        [StringLength(20)]
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên loại thành viên không được để trống")]
        [Display(Name = "Tên loại thành viên*")]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
