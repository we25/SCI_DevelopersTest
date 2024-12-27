using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts.IRepository.Lookups
{
    public interface IJobTitleRepositoryAsync
    {
        Task<JobTitleDTO> GetByIdAsync(int JT_Id);
        Task<List<JobTitleAddDTO>> GetByNameAsync(string JT_Name);
        Task<List<JobTitleDTO>> GetByDepartmentIdAsync(int Dept_Id);
        Task<List<JobTitleAndDepartmentDTO>> GetJobTitleWithDepartmentAsync();
    }
}