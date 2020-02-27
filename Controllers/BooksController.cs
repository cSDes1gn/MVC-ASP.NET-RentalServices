using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalServices.Models;

namespace RentalServices.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Random
        public IActionResult Random()
        {
            var book = new Book() { Name = "Mathematics of Machine Learning" };
            return View(book);
        }
    }
}