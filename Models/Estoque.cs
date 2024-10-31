using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraMVC.Models
{
    public class Estoque
    {
        //KEY é uma chave primária
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter até 100 caracteres.")]
        public string Nome { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }


        [Display(Name = "Tipo de Cookie")]
        [ForeignKey("TipoCookieId")]
        public Guid TipoCookieId { get; set; }
        public TipoCookie? TipoCookie { get; set; }

    }
}
