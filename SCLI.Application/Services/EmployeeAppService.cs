using AutoMapper;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts;
using SCLI.Application.Contracts.IRepository.Operation;
using SCLI.Application.DTO_s.DTO_Operation.D_Employee;
using SCLI.Domain.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        IBaseRepositoryAsync<Employee> baseRepository;
        IEmployeeRepositoryAsync employeeRepository;
        IMapper mapper;
        public EmployeeAppService(IBaseRepositoryAsync<Employee> baseRepository, IEmployeeRepositoryAsync employeeRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        #region Base Repository
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var data = await baseRepository.GetAllAsync();
            var dataList = new List<EmployeeDTO>();
            var dataDto = mapper.Map(data, dataList);
            return dataDto;
        }
        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeAddDTO item)
        {
            Employee employee = new Employee();
            mapper.Map(item, employee);
            var data = await baseRepository.AddAsync(employee);
            EmployeeDTO dataDto = new EmployeeDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO item)
        {
            Employee employee = new Employee();
            mapper.Map(item, employee);
            var data = await baseRepository.UpdateAsync(employee);
            EmployeeDTO dataDto = new EmployeeDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        public async Task<EmployeeDTO> RemoveEmployeeAsync(EmployeeDTO item)
        {
            Employee employee = new Employee();
            mapper.Map(item, employee);
            var data = await baseRepository.RemoveAsync(employee);
            EmployeeDTO dataDto = new EmployeeDTO();
            mapper.Map(data, dataDto);
            return dataDto;
        }
        #endregion

        #region Employee Repository
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int Emp_Id)
        {
            var data = await employeeRepository.GetByIdAsync(Emp_Id);
            return data;
        }
        public async Task<List<EmployeeMainDataDTO>> GetEmployeesByNameAsync(string Emp_Name)
        {
            var data = await employeeRepository.GetByNameAsync(Emp_Name);
            return data;
        }
        public async Task<List<EmployeeInfosDTO>> GetAllInfosAsync()
        {
            var data = await employeeRepository.GetAllInfosAsync();
            return data;
        }
        #endregion

        #region Base & Employee Repository
        public async Task<EmployeeDTO> RemoveEmployeeByIdAsync(int emp_id)
        {
            var data = await employeeRepository.GetByIdAsync(emp_id);
            Employee employee = new Employee();
            mapper.Map(data, employee);
            var dataDeleted = await baseRepository.RemoveAsync(employee);
            EmployeeDTO employeeDTO = new EmployeeDTO();
            var dataDto = mapper.Map(dataDeleted, employeeDTO);
            return dataDto;
        }
        #endregion
    }
}
