using System.ComponentModel.DataAnnotations;

namespace LISTA06Q03.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }



        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Peso { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Altura { get; set; }

    }
}
