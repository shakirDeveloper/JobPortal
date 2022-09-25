using JobPortal.Interface;
using JobPortalBLL.Service;
using JobPortalDTOs;
using JobPortalWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeProfileService _empService;

        //public HomeController(ILogger<HomeController> logger, EmployeeProfileService employeeProfileService)
        public HomeController(IEmployeeProfileService employeeProfileService)
        {
            //_logger = logger;
            _empService = employeeProfileService;
        }

        public IActionResult Index()
        {
            var employees = _empService.GetAllEmployeeProfile();
            return View(employees);
        }

        public IActionResult EmploymentForm() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmploymentForm( PersonalInformationDto form)
        {
            var _personalInformation = _empService.CreateEmployeeProfile(form);
            if (_personalInformation.id
                 > 0)
            {
                ViewBag.Message = "Record saved";
            }
            else {
                ViewBag.Message = "Record save failed";
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}