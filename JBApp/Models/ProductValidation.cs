using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBApp.Models
{
    public partial class Product
    {
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Description);
        }
    }
}