using EmployeeManager.Models;
using EmployeeManager.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    // nous avons fait herite notre clase de Controller de Asp.Net puisqu'elle nous offre plus de
    
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IEmployeeServices employeeServices,
                              IWebHostEnvironment hostingEnvironment) // injection du service employe et  du service qui permet de naviguer dans l'environnement
        {
            _employeeServices = employeeServices;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("")]
        [Route("/")]
        public JsonResult Index()
        {
            //Employee employeeModel = _employeeServices.GetEmployee(1);
            //return Json(new {id= employeeModel.Id, name = employeeModel.Name }); 
            List<Employee> modelList = _employeeServices.GetAllEmployee();
            return Json(modelList);
        }

        // [Route("[action]/{id?}")]
        [Route("{id?}")]
        public ViewResult EmployeeView(int? id)
        {
            int defaultID = _employeeServices.GetAllEmployee().First<Employee>().Id;
            Employee employeeModel = _employeeServices.GetEmployee(id?? defaultID);
            if(employeeModel == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFoundView");
            }
            ViewBag.employeeModel = employeeModel;
            ViewBag.PageTitle = "Employee Details";
            return View();
            // on peux aussi utiliser View("cheminaccees Nom_Vue_A_Afficher")
        }

       // [Route("[action]")]
        public ViewResult AllEmployeeView() 
        {
            AllEmployeeViewModel AllemployeeModel = new AllEmployeeViewModel()
            {
                EmployeeListModel = _employeeServices.GetAllEmployee(),
                PageTitle = "All Employee details"
            };  
            return View(AllemployeeModel);
            // on peux aussi utiliser View("cheminaccees Nom_Vue_A_Afficher")
        }

       // [Route("[action]")]
       [HttpGet]
        public ViewResult CreateEmployeeView() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployeeView(CreateEmployeeViewModel createModel)
        {
            if (ModelState.IsValid) 
            {
                string uniqueFileName = null;
                if (createModel.Photo != null)
                {
                    string uploadFolder =  Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + createModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    createModel.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Employee newEmployee = createModel.EmployeeModel;
                newEmployee.Photopath = uniqueFileName;

                    _employeeServices.AddEmployee(newEmployee);
                // Maintenant on va rediriger cette action a l'action EmployeeView afin que le nouvel employe soit presente a la vue
                return RedirectToAction("EmployeeView", new { id = newEmployee.Id });
            }
            return View();
        }

        [Route("{id?}")]
        [HttpGet]
        public ViewResult EmployeeEditView(int id) 
        {
            Employee employee = _employeeServices.GetEmployee(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFoundView");
            }

            EditEmployeeViewModel edithModel = new EditEmployeeViewModel()
            {
                EmployeeModel = employee,
                ExistingPhotoPath = employee.Photopath,
            };
            return View(edithModel);
        }

        [Route("{id?}")]
        [HttpPost]
        public IActionResult EmployeeEditView(EditEmployeeViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (editModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + editModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    editModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = _employeeServices.GetEmployee(editModel.EmployeeModel.Id);
                newEmployee.Name = editModel.EmployeeModel.Name;
                newEmployee.Email = editModel.EmployeeModel.Email;
                newEmployee.Department = editModel.EmployeeModel.Department;
                newEmployee.Photopath = uniqueFileName;

                _employeeServices.UpdateEmployee(newEmployee); 
                // Maintenant on va rediriger cette action a l'action EmployeeView afin que le nouvel employe soit presente a la vue
                return RedirectToAction("EmployeeView", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
