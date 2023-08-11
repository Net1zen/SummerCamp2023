using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorWeb.Models
{
    //[Table("Moneda")]
    public class Moneda
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(3)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

 
    }
}
