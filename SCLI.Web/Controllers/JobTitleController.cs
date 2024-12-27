using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCLI.Web.Models.ViewModels.DepartmentViewModels;
using SCLI.Web.Models.ViewModels.JobTitleViewModels;

namespace SCLI.Web.Controllers
{
    public class JobTitleController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            //var data = await client.GetFromJsonAsync<List<JobTitleVM>>("/api/JobTitle/GetAll");
            //return View(data);

            var data = await client.GetFromJsonAsync<List<JobTitleAndDepartmentVM>>("/api/JobTitle/GetJobTitleWithDepartment");
            return View(data);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var DepartmentData = await client.GetFromJsonAsync<List<DepartmentVM>>("/api/Department/GetAll");
            ViewBag.DepartmentList = new SelectList(DepartmentData, "id", "departmentName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobTitleAddVM jobTitleVM)
        {
            if(ModelState.IsValid)
            {
                var data = await client.PostAsJsonAsync("/api/JobTitle/Add", jobTitleVM);
                return RedirectToAction("Index", "JobTitle");
            }
            return View(jobTitleVM);
        }

        //GET
        public async Task<IActionResult> Edit(int Id)
        {
            var DepartmentData = await client.GetFromJsonAsync<List<DepartmentVM>>("/api/Department/GetAll");
            ViewBag.DepartmentList = new SelectList(DepartmentData, "id", "departmentName");

            var data = await client.GetFromJsonAsync<JobTitleVM>("/api/JobTitle/GetById?JT_Id=" + Id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobTitleVM jobVM)
        {
            if (ModelState.IsValid)
            {
                var data = await client.PutAsJsonAsync("/api/JobTitle/Update", jobVM);
                return RedirectToAction("Index", "JobTitle");
            }
            return View(jobVM);
        }

        //GET
        public async Task<IActionResult> Remove(int Id)
        {
            var data = await client.GetFromJsonAsync<JobTitleVM>("/api/JobTitle/GetById?JT_Id=" + Id);
            return View(data);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirme(int Id)
        {
            var data = await client.DeleteAsync("/api/JobTitle/RemoveById?jt_id=" + Id);
            return RedirectToAction("Index", "JobTitle");
        }
    }
}
