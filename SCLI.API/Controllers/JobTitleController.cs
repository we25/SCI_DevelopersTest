using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCLI.Application.Contracts;
using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;

namespace SCLI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        IJobTitleAppService appService;
        public JobTitleController(IJobTitleAppService appService)
        {
            this.appService = appService;
        }
                
        [HttpGet]
        public async Task<List<JobTitleDTO>> GetAll()
        {
            var data = await appService.GetAllJobTitlesAsync();
            return data;
        }

        [HttpGet]
        public async Task<JobTitleDTO> GetById(int JT_Id)
        {
            var data = await appService.GetJobTitleByIdAsync(JT_Id);
            return data;
        }

        [HttpGet]
        public async Task<List<JobTitleAddDTO>> GetByName(string JT_Name)
        {
            var data = await appService.GetJobTitlesByNameAsync(JT_Name);
            return data;
        }

        [HttpGet]
        public async Task<List<JobTitleDTO>> GetByDepartmentId(int Dept_Id)
        {
            var data = await appService.GetByDepartmentIdAsync(Dept_Id);
            return data;
        }
        
        [HttpGet]
        public async Task<List<JobTitleAndDepartmentDTO>> GetJobTitleWithDepartment()
        {
            var data = await appService.GetJobTitleWithDepartmentAsync();
            return data;
        }

        [HttpPost]
        public async Task<JobTitleDTO> Add(JobTitleAddDTO item)
        {
            var data = await appService.AddJobTitleAsync(item);
            return data;
        }

        [HttpPut]
        public async Task<JobTitleDTO> Update(JobTitleDTO item)
        {
            var data = await appService.UpdateJobTitleAsync(item);
            return data;
        }

        [HttpDelete]
        public async Task<JobTitleDTO> Remove(JobTitleDTO item)
        {
            var data = await appService.RemoveJobTitleAsync(item);
            return data;
        }

        [HttpDelete]
        public async Task<JobTitleDTO> RemoveById(int jt_id)
        {
            var data = await appService.RemoveJobTitleByIdAsync(jt_id);
            return data;
        }
    }
}
