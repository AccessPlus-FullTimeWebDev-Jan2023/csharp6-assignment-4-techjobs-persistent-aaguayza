using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

/*


--Complete Index() so that it passes all of the Employer objects in the database to the view.

--Create an instance of AddEmployerViewModel inside of the Create() method and pass the instance into the View() return method.

--Add the appropriate code to ProcessAddEmployerForm() so that it will process form submissions and make sure that only valid Employer objects are being saved to the database.

--You want to add a new employer if the model is valid.
Else redirect users back to the form

About() takes an id as a parameter. It will create an Employer object by searching through the Employers table in DbContext until it finds the provided id. It will pass the employer object to the view.
Consider using the .Find() method to search the database.
 */



namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location,
                };
                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            return View("Create", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
                Employer selectedEmployer = context.Employers.Find(id);
            return View(selectedEmployer);
        }

    }
}


