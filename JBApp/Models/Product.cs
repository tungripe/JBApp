using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JBApp.Models
{
    public partial class Product
    {
        [Key]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }
    }
}