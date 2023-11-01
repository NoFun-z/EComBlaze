using System;
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
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
