namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Contents = new HashSet<Content>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        [StringLength(2)]
        public string Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
    }
}
