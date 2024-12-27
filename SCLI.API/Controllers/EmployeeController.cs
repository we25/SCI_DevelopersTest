using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCLI.Application.Contracts;
using SCLI.Application.DTO_s.DTO_Operation.D_Employee;

namespace SCLI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeAppService appService;
        public EmployeeController(IEmployeeAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAll()
        {
            var data = await appService.GetAllEmployeesAsync();
            return data;
        }

        [HttpGet]
        public async Task<List<EmployeeInfosDTO>> GetAllInfos()
        {
            var data = await appService.GetAllInfosAsync();
            return data;
        }

        [HttpGet]
        public async Task<EmployeeDTO> GetById(int Emp_Id)
        {
            var data = await appService.GetEmployeeByIdAsync(Emp_Id);
            return data;
        }

        [HttpGet]
        public async Task<List<EmployeeMainDataDTO>> GetByName(string Emp_Name)
        {
            var data = await appService.GetEmployeesByNameAsync(Emp_Name);
            return data;
        }

        [HttpPost]
        public async Task<EmployeeDTO> Add(EmployeeAddDTO item)
        {
            var data = await appService.AddEmployeeAsync(item);
            return data;
        }

        [HttpPut]
        public async Task<EmployeeDTO> Update(EmployeeDTO item)
        {
            var data = await appService.UpdateEmployeeAsync(item);
            return data;
        }

        [HttpDelete]
        public async Task<EmployeeDTO> Remove(EmployeeDTO item)
        {
            var data = await appService.RemoveEmployeeAsync(item);
            return data;
        }

        [HttpDelete]
        public async Task<EmployeeDTO> RemoveById(int emp_id)
        {
            var data = await appService.RemoveEmployeeByIdAsync(emp_id);
            return data;
        }
    }
}
