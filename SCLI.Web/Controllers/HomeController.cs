using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCLI.Web.Models;
using SCLI.Web.Models.ViewModels.DepartmentViewModels;
using SCLI.Web.Models.ViewModels.EmployeeViewModels;
using SCLI.Web.Models.ViewModels.JobTitleViewModels;
using SCLI.Web.Models.ViewModels.SystemCodeViewModels;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SCLI.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = await client.GetFromJsonAsync<List<EmployeeIndexVM>>("api/Employee/GetAllInfos");
            return View(data);
        }

        public async Task<IActionResult> Search()
        {
            var data = await client.GetFromJsonAsync<List<EmployeeMainDataVM>>("api/Employee/GetAllInfos");
            return View(data);
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string Name)
        {
            // Check if a name was provided for filtering
            if (!string.IsNullOrWhiteSpace(Name))
            {
                // Retrieve filtered data from the API by sending the name as a query parameter
                var data = await client.GetFromJsonAsync<List<EmployeeMainDataVM>>("api/Employee/GetByName?Emp_Name=" + Name);
                return View(data);
            }
            else
            {
                // If no name is provided, return all data
                var data = await client.GetFromJsonAsync<List<EmployeeMainDataVM>>("api/Employee/GetAllInfos");
                return View(data);
            }
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var GenderData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=1");
            ViewBag.GenderList = new SelectList(GenderData, "id", "staticValue");

            var MaritalStatusData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=2");
            ViewBag.MaritalStatusList = new SelectList(MaritalStatusData, "id", "staticValue");

            var RelegionData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=3");
            ViewBag.RelegionList = new SelectList(RelegionData, "id", "staticValue");
                    
            var DepartmentData = await client.GetFromJsonAsync<List<DepartmentVM>>("/api/Department/GetAll");
            ViewBag.DepartmentList = new SelectList(DepartmentData, "id", "departmentName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeAddVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var data = await client.PostAsJsonAsync("api/Employee/Add", employeeVM);
                return RedirectToAction("Index", "Home");
            }
            return View(employeeVM);
        }

        //GET
        public async Task<IActionResult> Edit(int Id)
        {
            var GenderData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=1");
            ViewBag.GenderList = new SelectList(GenderData, "id", "staticValue");

            var MaritalStatusData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=2");
            ViewBag.MaritalStatusList = new SelectList(MaritalStatusData, "id", "staticValue");

            var RelegionData = await client.GetFromJsonAsync<List<SystemCodeVM>>("/api/SystemCode/GetByTypeId?TypeId=3");
            ViewBag.RelegionList = new SelectList(RelegionData, "id", "staticValue");

            var DepartmentData = await client.GetFromJsonAsync<List<DepartmentVM>>("/api/Department/GetAll");
            ViewBag.DepartmentList = new SelectList(DepartmentData, "id", "departmentName");

            var data = await client.GetFromJsonAsync<EmployeeVM>("/api/Employee/GetById?Emp_Id=" + Id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var data = await client.PutAsJsonAsync("/api/Employee/Update", employeeVM);
                return RedirectToAction("Index", "Home");
            }
            return View(employeeVM);
        }

        //GET
        public async Task<IActionResult> Remove(int Id)
        {
            var data = await client.GetFromJsonAsync<EmployeeVM>("/api/Employee/GetById?Emp_Id=" + Id);
            return View(data);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirme(int Id)
        {
            var data = await client.DeleteAsync("/api/Employee/RemoveById?emp_id=" + Id);
            return RedirectToAction("Index", "Home");
        }

        #region Ajax Request

        [HttpPost]  // Secuirty
        public async Task<JsonResult> GetJobsByDepartmentId(int dept_id)
        {
            var data = await client.GetFromJsonAsync<List<JobTitleVM>>("/api/JobTitle/GetByDepartmentId?Dept_Id=" + dept_id);
            return Json(data);
        }

        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
