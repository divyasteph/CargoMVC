namespace CargoManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        public int Employee_ID { get; set; }

        [StringLength(20)]
        public string Employee_Name { get; set; }

        [StringLength(20)]
        public string Employee_Department { get; set; }

        public int? Employee_Designation { get; set; }

        [StringLength(20)]
        public string Employee_Mobile { get; set; }

        [StringLength(10)]
        public string ActiveStatus { get; set; }
    }
}
