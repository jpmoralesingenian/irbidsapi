using System;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrbidsAPI.Models
{
    /// <summary>
    /// A grade is what the user sends to try and create an option.
    /// It can become an Attempt, if it behaves!
    /// This is not a database object
    /// </summary>
    public class Grade
    {
        [Required]
        [StringLength(100)]
        public String Ani { get; set; }
        [StringLength(200)]
        [DataType(DataType.Url)]
        public String RecordedURL { get; set; }

        public int WordId { get; set; }
    }
}
