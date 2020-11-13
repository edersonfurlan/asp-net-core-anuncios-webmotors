using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotors.UI.WEB.Models
{
    [Table("Anuncios")]
    public sealed class AnuncioMOD
    {
        [Key]
        [Display(Name="Código")]
        public int ID { get; set; }

        [Required(ErrorMessage="Por favor, selecione a marca")]
        [Display(Name = "Marca")]
        public int marca { get; set; }

        [Display(Name = "Marca")]
        public string marca_nome { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o modelo")]
        [Display(Name = "Modelo")]
        public int modelo { get; set; }

        [Display(Name = "Modelo")]
        public string modelo_nome { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a versão")]
        [Display(Name = "Versão")]
        public int versao { get; set; }

        [Display(Name = "Versão")]
        public string versao_nome { get; set; }

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
