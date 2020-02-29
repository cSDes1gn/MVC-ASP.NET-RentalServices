using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalServices.Models;
using RentalServices.ViewModels;

namespace RentalServices.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Steven"},
                new Customer {Name = "Aaron"}
            };

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }
    }
}