using SCLI.Application.DTO_s.DTO_Lookups.D_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts
{
    public interface IDepartmentAppService
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int Dept_Id);
        Task<List<DepartmentAddDTO>> GetDepartmentByNameAsync(string Dept_Name);
        Task<DepartmentDTO> AddDepartmentAsync(DepartmentAddDTO item);
        Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO item);
        Task<DepartmentDTO> RemoveDepartmentAsync(DepartmentDTO item);
        Task<DepartmentDTO> RemoveDepartmentByIdAsync(int dept_id);
    }
}
