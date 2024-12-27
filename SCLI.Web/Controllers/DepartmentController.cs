using Microsoft.AspNetCore.Mvc;
using SCLI.Web.Models.ViewModels.DepartmentViewModels;
using System.Net.Http.Json;

namespace SCLI.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var data = await client.GetFromJsonAsync<List<DepartmentVM>>("/api/Department/GetAll");
            return View(data);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentAddVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                var data = await client.PostAsJsonAsync("/api/Department/Add", departmentVM);
                return RedirectToAction("Index", "Department");
            }
            return View(departmentVM);
        }

        //GET
        public async Task<IActionResult> Edit(int Id)
        {
            var data = await client.GetFromJsonAsync<DepartmentVM>("/api/Department/GetById?Dept_Id=" + Id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                var data = await client.PutAsJsonAsync("/api/Department/Update", departmentVM);
                return RedirectToAction("Index", "Department");
            }
            return View(departmentVM);
        }

        //GET
        public async Task<IActionResult> Remove(int Id)
        {
            var data = await client.GetFromJsonAsync<DepartmentVM>("/api/Department/GetById?Dept_Id=" + Id);
            return View(data);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirme(int Id)
        {
            var data = await client.DeleteAsync("/api/Department/RemoveById?dept_id=" + Id);
            return RedirectToAction("Index", "Department");
        }
    }
}
