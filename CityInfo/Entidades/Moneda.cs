using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
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
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(3)]
        public string Symbol { get; set; }


    }
}
