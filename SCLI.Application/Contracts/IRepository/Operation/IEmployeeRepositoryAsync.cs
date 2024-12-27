using SCLI.Application.DTO_s.DTO_Operation.D_Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts.IRepository.Operation
{
    public interface IEmployeeRepositoryAsync
    {
        Task<List<EmployeeInfosDTO>> GetAllInfosAsync();
        Task<EmployeeDTO> GetByIdAsync(int Emp_Id);
        Task<List<EmployeeMainDataDTO>> GetByNameAsync(string Emp_Name);
    }
}
