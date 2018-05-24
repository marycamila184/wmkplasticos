using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VmkPlasticos.Models
{
    public class BudgetModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Linha { get; set; }
        public List<ProductsModel> Products { get; set; }
    }
}