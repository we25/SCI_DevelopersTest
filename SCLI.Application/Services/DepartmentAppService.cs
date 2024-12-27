using AutoMapper;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts;
using SCLI.Application.Contracts.IRepository.Lookups;
using SCLI.Application.DTO_s.DTO_Lookups.D_Department;
using SCLI.Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Services
{
    public class DepartmentAppService : IDepartmentAppService
    {
        IBaseRepositoryAsync<Department> baseRepository;
        IDepartmentRepositoryAsync departmentRepository;
        IMapper mapper;
        public DepartmentAppService(IBaseRepositoryAsync<Department> baseRepository, IDepartmentRepositoryAsync departmentRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        #region Base Repository
        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var data = await baseRepository.GetAllAsync();
            var dataList = new List<DepartmentDTO>();
            var dataDto = mapper.Map(data, dataList);
            return dataDto;
        }
        public async Task<DepartmentDTO> AddDepartmentAsync(DepartmentAddDTO item)
        {
            Department department = new Department();
            mapper.Map(item, department);
            var data = await baseRepository.AddAsync(department);
            DepartmentDTO dataDto = new DepartmentDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO item)
        {
            Department department = new Department();
            mapper.Map(item, department);
            var data = await baseRepository.UpdateAsync(department);
            DepartmentDTO dataDto = new DepartmentDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<DepartmentDTO> RemoveDepartmentAsync(DepartmentDTO item)
        {
            Department department = new Department();
            mapper.Map(item, department);
            var data = await baseRepository.RemoveAsync(department);
            DepartmentDTO dataDto = new DepartmentDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        #endregion

        #region Department Repository
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int Dept_Id)
        {
            var data = await departmentRepository.GetByIdAsync(Dept_Id);
            return data;
        }
        public async Task<List<DepartmentAddDTO>> GetDepartmentByNameAsync(string Dept_Name)
        {
            var data = await departmentRepository.GetByNameAsync(Dept_Name);
            return data;
        }
        #endregion

        #region Base & Department Repository
        public async Task<DepartmentDTO> RemoveDepartmentByIdAsync(int dept_id)
        {
            var data = await departmentRepository.GetByIdAsync(dept_id);
            Department department = new Department();
            mapper.Map(data, department);
            var dataDeleted = await baseRepository.RemoveAsync(department);
            DepartmentDTO deptDTO = new DepartmentDTO();
            var dataDto = mapper.Map(dataDeleted, deptDTO);
            return dataDto;
        }
        #endregion
    }
}
