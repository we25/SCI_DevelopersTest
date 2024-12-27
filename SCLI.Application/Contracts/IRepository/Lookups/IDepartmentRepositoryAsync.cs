using SCLI.Application.DTO_s.DTO_Lookups.D_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts.IRepository.Lookups
{
    public interface IDepartmentRepositoryAsync
    {
        Task<DepartmentDTO> GetByIdAsync(int Dept_Id);
        Task<List<DepartmentAddDTO>> GetByNameAsync(string Dept_Name);
    }
}
