namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            bookingCargo = new HashSet<bookingCargo>();
        }

        [Key]
        public int Product_ID { get; set; }

        [StringLength(20)]
        public string Product_Name { get; set; }

        [StringLength(20)]
        public string Product_Type { get; set; }

        public int? Product_Price { get; set; }
        public int? Shipping_Charge { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingCargo> bookingCargo { get; set; }
    }
}
