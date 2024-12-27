using AutoMapper;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts;
using SCLI.Application.Contracts.IRepository.Lookups;
using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;
using SCLI.Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Services
{
    public class JobTitleAppService : IJobTitleAppService
    {
        IBaseRepositoryAsync<JobTitle> baseRepository;
        IJobTitleRepositoryAsync jobTitleRepository;
        IMapper mapper;
        public JobTitleAppService(IBaseRepositoryAsync<JobTitle> baseRepository, IJobTitleRepositoryAsync jobTitleRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.jobTitleRepository = jobTitleRepository;
            this.mapper = mapper;
        }

        #region Base Repository      
        public async Task<List<JobTitleDTO>> GetAllJobTitlesAsync()
        {
            var data = await baseRepository.GetAllAsync();
            var dataList = new List<JobTitleDTO>();
            var dataDto = mapper.Map(data, dataList);
            return dataDto;
        }
        public async Task<JobTitleDTO> AddJobTitleAsync(JobTitleAddDTO item)
        {
            JobTitle title = new JobTitle();
            mapper.Map(item, title);
            var data = await baseRepository.AddAsync(title);
            JobTitleDTO dataDto = new JobTitleDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<JobTitleDTO> UpdateJobTitleAsync(JobTitleDTO item)
        {
            JobTitle title = new JobTitle();
            mapper.Map(item, title);
            var data = await baseRepository.UpdateAsync(title);
            JobTitleDTO dataDto = new JobTitleDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<JobTitleDTO> RemoveJobTitleAsync(JobTitleDTO item)
        {
            JobTitle title = new JobTitle();
            mapper.Map(item, title);
            var data = await baseRepository.RemoveAsync(title);
            JobTitleDTO dataDto = new JobTitleDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        #endregion

        #region JobTitle Repository
        public async Task<JobTitleDTO> GetJobTitleByIdAsync(int JT_Id)
        {
            var data = await jobTitleRepository.GetByIdAsync(JT_Id);
            return data;
        }
        public async Task<List<JobTitleAddDTO>> GetJobTitlesByNameAsync(string JT_Name)
        {
            var data = await jobTitleRepository.GetByNameAsync(JT_Name);
            return data;
        }
        public async Task<List<JobTitleDTO>> GetByDepartmentIdAsync(int Dept_Id)
        {
            var data = await jobTitleRepository.GetByDepartmentIdAsync(Dept_Id);
            return data;
        }

        public async Task<List<JobTitleAndDepartmentDTO>> GetJobTitleWithDepartmentAsync()
        {
            var data = await jobTitleRepository.GetJobTitleWithDepartmentAsync();
            return data;
        }
        #endregion

        #region Base & JobTitle Repository
        public async Task<JobTitleDTO> RemoveJobTitleByIdAsync(int jt_id)
        {
            var data = await jobTitleRepository.GetByIdAsync(jt_id);
            JobTitle title = new JobTitle();
            mapper.Map(data, title);
            var dataDeleted = await baseRepository.RemoveAsync(title);
            JobTitleDTO jobTitleDTO = new JobTitleDTO();
            var dataDto = mapper.Map(dataDeleted, jobTitleDTO);
            return dataDto;
        }
        #endregion
    }
}
