using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalServices.Models
{
    public class Customer
    {
        // Data annotations modify our model parameters allow these attributes to be modified across the whoe project
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Customer ID required")]
        [Range(1000, 9999, ErrorMessage = "Please enter a number within the range 1000 and 9999")]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer name required")]
        [Range(1000, 9999, ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Password length must be between 10 and 100 characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage =" Your passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
