namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gatePass")]
    public partial class gatePass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int number { get; set; }

        public int? truck_number { get; set; }

        public int? city_id { get; set; }

        public DateTime issued_date { get; set; }

        public virtual city city { get; set; }
    }
}
