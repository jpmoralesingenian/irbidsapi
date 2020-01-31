using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrbidsAPI.Models
{
    /// <summary>
    /// Models a platform user. 
    /// Since there is no registration and no login, this does not know the name, just the phonenumber (Ani)
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Ani { get; set; }

        [Required]
        public float Score { get; set; }
    }
}
