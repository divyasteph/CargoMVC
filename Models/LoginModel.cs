using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoManagement.Models
{
    public class LoginModel
    {
        [Key]
            public int ID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="enter the username less than 50 char")]
            public string UserName { get; set; }
        [MaxLength(8,ErrorMessage ="enter the password with 8 char")]
            public string UserPassword { get; set; }
        
    }
}
