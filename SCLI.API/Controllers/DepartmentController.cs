using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCLI.Application.Contracts;
using SCLI.Application.DTO_s.DTO_Lookups.D_Department;

namespace SCLI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentAppService appService;
        public DepartmentController(IDepartmentAppService appService)
        {
            this.appService = appService;
        }
                          
        [HttpGet]
        public async Task<List<DepartmentDTO>> GetAll()
        {
            var data = await appService.GetAllDepartmentsAsync();
            return data;
        }

        [HttpGet]
        public async Task<DepartmentDTO> GetById(int Dept_Id)
        {
            var data = await appService.GetDepartmentByIdAsync(Dept_Id);
            return data;
        }

        [HttpGet]
        public async Task<List<DepartmentAddDTO>> GetByName(string Dept_Name)
        {
            var data = await appService.GetDepartmentByNameAsync(Dept_Name);
            return data;
        }

        [HttpPost]
        public async Task<DepartmentDTO> Add(DepartmentAddDTO item)
        {
            var data = await appService.AddDepartmentAsync(item);
            return data;
        }

        [HttpPut]
        public async Task<DepartmentDTO> Update(DepartmentDTO item)
        {
            var data = await appService.UpdateDepartmentAsync(item);
            return data;
        }
        
        [HttpDelete]
        public async Task<DepartmentDTO> Remove(DepartmentDTO item)
        {
            var data = await appService.RemoveDepartmentAsync(item);
            return data;
        }

        [HttpDelete]
        public async Task<DepartmentDTO> RemoveById(int dept_id)
        {
            var data = await appService.RemoveDepartmentByIdAsync(dept_id);
            return data;
        }
    }
}
