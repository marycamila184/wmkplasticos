using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VmkPlasticos.Models
{
    public class ContactModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Required]
        public string Assunto { get; set; }
        [Required]
        public string Mensagem { get; set; }
    }
}