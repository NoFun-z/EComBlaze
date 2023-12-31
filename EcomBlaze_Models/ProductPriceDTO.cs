﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomBlaze_Models
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }
        [Required (ErrorMessage = "Product must have a size")]
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
