﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorWeb.Models
{
    //[Table("Moneda")]
    public class Moneda
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }

 
    }
}
