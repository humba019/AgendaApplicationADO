using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaWebApplication.Models
{
    public class Pessoa
    {

        [Display(Name = "Id")]
        public int idPessoa { get; set; }
        [Required(ErrorMessage = "Informe um nome para o contato")]
        public string nomePessoa { get; set; }
        [Required(ErrorMessage = "Informe um telefone para o contato")]
        public string telefonePessoa { get; set; }
        [Required(ErrorMessage = "Informe um e-mail para o contato")]
        public string emailPessoa { get; set; }
    

    }
}