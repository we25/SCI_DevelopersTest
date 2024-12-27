using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts
{
    public interface IJobTitleAppService
    {
        Task<List<JobTitleDTO>> GetAllJobTitlesAsync();
        Task<JobTitleDTO> GetJobTitleByIdAsync(int JT_Id);
        Task<List<JobTitleAddDTO>> GetJobTitlesByNameAsync(string JT_Name);
        Task<List<JobTitleDTO>> GetByDepartmentIdAsync(int Dept_Id);
        Task<List<JobTitleAndDepartmentDTO>> GetJobTitleWithDepartmentAsync();
        Task<JobTitleDTO> AddJobTitleAsync(JobTitleAddDTO item);
        Task<JobTitleDTO> UpdateJobTitleAsync(JobTitleDTO item);
        Task<JobTitleDTO> RemoveJobTitleAsync(JobTitleDTO item);
        Task<JobTitleDTO> RemoveJobTitleByIdAsync(int jt_id);
    }
}