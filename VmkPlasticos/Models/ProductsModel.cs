using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VmkPlasticos.Models
{
    public class ProductsModel
    {
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }

        public string Unidades { get; set; }
    }
}