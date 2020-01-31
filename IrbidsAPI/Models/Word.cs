using System;
using System.ComponentModel.DataAnnotations;

namespace IrbidsAPI.Models
{
    /// <summary>
    /// Clase de negocio, contiene la información de que es lo que tiene una palabra.
    /// Inspired by https://medium.com/net-core/how-to-build-a-restful-api-with-asp-net-core-fb7dd8d3e5e3
    /// </summary>
    public class Word
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]       
        public string TextEnglish { get; set; }
        [Required]
        [StringLength(100)]
        public string TextSpanish { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.Url)]
        public string AudioURL { get; set; }
        [Required]        
        public int Level { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Language { get; set; }
    }
}
