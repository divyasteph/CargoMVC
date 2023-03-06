namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            bookingCargo = new HashSet<bookingCargo>();
        }

        [Key]
        public int Customer_ID { get; set; }

        [StringLength(20)]
        public string Customer_Name { get; set; }

        [StringLength(20)]
        public string Customer_Address { get; set; }

        [StringLength(20)]
        public string Customer_Mobile { get; set; }

        [StringLength(20)]
        public string Customer_Email { get; set; }

        [StringLength(10)]
        public string ActiveStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingCargo> bookingCargo { get; set; }
    }
}
