namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookingCargo")]
    public partial class bookingCargo
    {
        [Key]
        public int Booking_ID { get; set; }

        public int? Customer_ID { get; set; }

        public int? Product_ID { get; set; }

        
        public int? Quantity { get; set; }
       
        public int? City_ID { get; set; }

        public int Amount { get; set; }
        public virtual customer customer { get; set; }

        public virtual product product { get; set; }
        public virtual city city { get; set; }
    }
}
