using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalServices.Models
{
    public class Customer
    {
        // Data annotations modify our model parameters
        [Range(1000, 9999, ErrorMessage = "Please enter a valid Customer ID")]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
