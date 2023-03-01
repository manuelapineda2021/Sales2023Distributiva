﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name="Categorías")]
        [Required (ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage="El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;
    }
}
