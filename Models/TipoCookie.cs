using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraMVC.Models
{
    public class TipoCookie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Sabor { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
       
    }
}
