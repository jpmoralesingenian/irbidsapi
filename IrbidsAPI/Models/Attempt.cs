using System;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrbidsAPI.Models
{
    /// <summary>
    /// An Attempt models a user trying to guess a word
    /// </summary>
    public class Attempt
    {
        public int Id { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [Required]
        public float Confidence { get; set; }

        [Required]
        public virtual Word Word { get; set; }

        [StringLength(200)]
        [DataType(DataType.Url)]
        public String RecordedURL { get; set; }

    }
}
