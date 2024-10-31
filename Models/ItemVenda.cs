using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocadoraMVC.Models
{
    public class ItemVenda
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Display(Name = "Cliente")]
        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        //[ForeignKey("ClienteId")]
        //public Guid ClienteId { get; set; }
        //public Cliente? Cliente { get; set; }


        [Display(Name = "Cookie")]
        [ForeignKey("CookieId")]
        public Guid CookieId { get; set; }
        public Cookie? Cookie { get; set; }


        [Display(Name = "Preço Unitário")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }


        [Display(Name = "Total")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }

        public decimal Total => Quantidade * PrecoUnitario;


    }
}
