using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDesafio.Models
{
    [Table("residencia")]
    public class CEP
    {
        [Column("id")]

        [Display(Name = "id")]
        public int id { get; set; }

        [Column("Residencia")]

        [Display(Name = "Residencia")]
        public int Residencia { get; set; }
    }
}
