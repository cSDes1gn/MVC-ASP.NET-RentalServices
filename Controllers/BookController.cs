using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalServices.Models;
using RentalServices.ViewModels;

namespace RentalServices.Controllers
{
    public class BookController : Controller
    {
        // Action Results Type ViewResult >> Helper method View()
        public IActionResult Random()
        {

            // Pass book and return the ViewResult
            //return View(book);
            //return Content("Hi");     //returns string written on page

            //return NotFound();  //Equivalent to old helper method: HttpNotFound()
            // These arguments are passed as the query string (?..)
            // return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });    //Redirects to the specified action using actionname, controllername and routeValues

            return View();
            
        }

        public IActionResult Edit(int id)
        {
            // We can pass this parameter as a query string in the url by: ... /Edit?id=1 and it would yield the same result as embedding 1 as a parameter: ... /Edit/1
            // Furthermore we can have id passed through form data.
            // However we have to ensure that id exists in the default route under Startup.cs: template: "{controller=Home}/{action=Index}/{id?}");
            return Content("id = " + id);
        }

        //Movies

        // 'int?' makes the parameter nullible (optional)
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            // Create book list from Models to pass into ViewModels list
            var books = new List<Book>
            {
                new Book {Name = "Mathematics of Machine Learning" },
                new Book {Name = "赤チャート"}
            };

            var viewModel = new BookViewModel
            {
                Book = books
            };

            return View(viewModel);
            // if optional pageIndex is empty then set it to default (1)
            //if (!pageIndex.HasValue)
            //    pageIndex = 1;
            // if sortBy is not specified assume default ("Name")
            //if (String.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";
            // navigating to /books with no parameters gives the defaults we just set as a string content but we can override the parameters by typing
            // a string query : /books?pageIndex=2&sortBy=ReleaseDate will give pageIndex=2 and sortBy=ReleaseDate
            // In order to embed the parameters in the url we need to change the Startup.cs route mapping url template ({controller=Home}/{action=Index}/{id?})
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // Month can be defined as a byte since max value is 12
        // NOTE: building custom routes is tedious and messy as a complex system will have a number of custom routes.
        // Furthermore these definitions are set string values so if a name is changed for a controller it will not update here making this approach not modular.
        // Instead of this we can use Attribute Routing
        // to apply constraint in attribute route we add ':' ten regex() which defines a regular expression and then the constraint
        // note we cant use verbatim since the regex parameter is not a string. Also we must escape (double up) special characters like { and } in regex
        // we can apply as many constraints as we want by appending new constraints with':' a list of all constraints can be found by: ASP.NET MVC Attribute Route Constraints
        [Route("books/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }


    }
}