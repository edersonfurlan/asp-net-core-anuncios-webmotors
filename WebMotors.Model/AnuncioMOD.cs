using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotors.Model
{
    [Table("Anuncios")]
    public sealed class AnuncioMOD
    {
        [Key]
        [Display(Name="Código")]
        public int ID { get; set; }

        [Required(ErrorMessage="Por favor, informe a marca")]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required(ErrorMessage = "Por favor, informe o modelo")]
        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a versão")]
        [Display(Name = "Versão")]
        public string versao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o ano")]
        [Display(Name = "Ano")]
        public int ano { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quilometragem")]
        [Display(Name = "Quilometragem")]
        public int quilometragem { get; set; }

        [Required(ErrorMessage = "Por favor, informe alguma observação")]
        [Display(Name = "Observações")]
        public string observacao { get; set; }
    }
}
