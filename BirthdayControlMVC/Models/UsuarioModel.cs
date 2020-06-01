using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayControlMVC.Models
{
    public class UsuarioModel
    {
        [Key]
        [Display(Name = "ID Usuário")]
        public int UsuarioID { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
