using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts.IRepository.Lookups;
using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;
using SCLI.Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure.RepositoryAsync.Lookups
{
    public class JobTitleRepositoryAsync : IJobTitleRepositoryAsync
    {
        SCLIAppContext appContext;
        public JobTitleRepositoryAsync(SCLIAppContext appContext)
        {
             this.appContext = appContext;
        }

        public async Task<JobTitleDTO> GetByIdAsync(int JT_Id)
        {
            var data = await appContext.jobTitles.SingleOrDefaultAsync(x => x.Id == JT_Id);
            if (data != null)
            {
                return new JobTitleDTO
                {
                    Id = JT_Id,
                    JobName = data.JobName,
                    DepartmentId = data.DepartmentId
                };
            }
            return new JobTitleDTO();
        }

        public async Task<List<JobTitleDTO>> GetByDepartmentIdAsync(int Dept_Id)
        {
            var data = await appContext.jobTitles.Where(x => x.DepartmentId == Dept_Id)
                .Select(a => new JobTitleDTO()
                {
                    Id = a.Id,
                    JobName = a.JobName,
                    DepartmentId = a.DepartmentId
                }).ToListAsync();
            return data;
        }

        public async Task<List<JobTitleAddDTO>> GetByNameAsync(string JT_Name)
        {
            var data = await appContext.jobTitles.Where(x => x.JobName.Contains(JT_Name))
                .Select(a => new JobTitleAddDTO
                {
                    JobName = a.JobName,
                    DepartmentId = a.DepartmentId
                }).ToListAsync();
            return data;
        }

        public async Task<List<JobTitleAndDepartmentDTO>> GetJobTitleWithDepartmentAsync()
        {
            var data = await appContext.jobTitles.Join(appContext.departments, job => job.DepartmentId, dept => dept.Id, (JT, DEPT) => new JobTitleAndDepartmentDTO()
            {
                Id = JT.Id,
                JobName = JT.JobName,
                DepartmentName = DEPT.DepartmentName
            }).ToListAsync();
            return data;
        }
    }
}