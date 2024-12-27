using SCLI.Application.DTO_s.DTO_Operation.D_Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts
{
    public interface IEmployeeAppService
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<List<EmployeeInfosDTO>> GetAllInfosAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int Emp_Id);
        Task<List<EmployeeMainDataDTO>> GetEmployeesByNameAsync(string Emp_Name);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeAddDTO item);
        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO item);
        Task<EmployeeDTO> RemoveEmployeeAsync(EmployeeDTO item);
        Task<EmployeeDTO> RemoveEmployeeByIdAsync(int emp_id);
    }
}
