using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contracts.IRepository.Operation;
using SCLI.Application.DTO_s.DTO_Operation.D_Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure.RepositoryAsync.Operation
{
    public class EmployeeRepositoryAsync : IEmployeeRepositoryAsync
    {
        SCLIAppContext appContext;
        public EmployeeRepositoryAsync(SCLIAppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<List<EmployeeInfosDTO>> GetAllInfosAsync()
        {
            var data = await appContext.employees
                .Join(appContext.systemCodes, employee => employee.GenderId, Gsystem => Gsystem.Id, (Employee, GS) => new { Employee, GS })
                .Join(appContext.systemCodes, marital => marital.Employee.MaritalStatusId, Msystem => Msystem.Id, (Marital, MS) => new { Marital, MS })
                .Join(appContext.systemCodes, relegion => relegion.Marital.Employee.RelegionId, Rsystem => Rsystem.Id, (Relegion, RS) => new { Relegion, RS })
                .Join(appContext.jobTitles, jobTitle => jobTitle.Relegion.Marital.Employee.JobTitleId, jb => jb.Id, (JobTitle, JB) => new { JobTitle, JB })
                .Join(appContext.departments, combined => combined.JobTitle.Relegion.Marital.Employee.DepatmentId, dept => dept.Id, (COMBINED, DEPT) => new EmployeeInfosDTO
                {
                    Id = COMBINED.JobTitle.Relegion.Marital.Employee.Id,
                    FullName = COMBINED.JobTitle.Relegion.Marital.Employee.FullName,
                    BrithDate = COMBINED.JobTitle.Relegion.Marital.Employee.BrithDate,
                    Gender = COMBINED.JobTitle.Relegion.Marital.GS.StaticValue,
                    MaritalStatus = COMBINED.JobTitle.Relegion.MS.StaticValue,
                    Relegion = COMBINED.JobTitle.RS.StaticValue,
                    JobTitleName = COMBINED.JB.JobName,
                    DepatmentName = DEPT.DepartmentName
                }).ToListAsync();
            return data;
        }

        public async Task<EmployeeDTO> GetByIdAsync(int Emp_Id)
        {
            var data = await appContext.employees.SingleOrDefaultAsync(x=>x.Id == Emp_Id);
            if (data != null)
            {
                return new EmployeeDTO
                {
                    Id = data.Id,
                    FullName = data.FullName,
                    BrithDate = data.BrithDate,
                    GenderId = data.GenderId,
                    Nationality = data.Nationality,
                    MaritalStatusId = data.MaritalStatusId,
                    RelegionId = data.RelegionId,
                    Phone = data.Phone,
                    Address = data.Address,
                    JobTitleId = data.JobTitleId,
                    DepatmentId = data.DepatmentId,
                    Education = data.Education,
                    Experience = data.Experience
                };
            }
            return new EmployeeDTO();
        }

        public async Task<List<EmployeeMainDataDTO>> GetByNameAsync(string Emp_Name)
        {
            var data = await appContext.employees.Where(x => x.FullName.Contains(Emp_Name))
                .Join(appContext.systemCodes, employee => employee.GenderId, Gsystem => Gsystem.Id, (Employee, GS) => new { Employee, GS })
                .Join(appContext.systemCodes, marital => marital.Employee.MaritalStatusId, Msystem => Msystem.Id, (Marital, MS) => new { Marital, MS })
                .Join(appContext.systemCodes, relegion => relegion.Marital.Employee.RelegionId, Rsystem => Rsystem.Id, (Relegion, RS) => new { Relegion, RS })
                .Join(appContext.jobTitles, jobTitle => jobTitle.Relegion.Marital.Employee.JobTitleId, jb => jb.Id, (JobTitle, JB) => new { JobTitle, JB })
                .Join(appContext.departments, combined => combined.JobTitle.Relegion.Marital.Employee.DepatmentId, dept => dept.Id, (COMBINED, DEPT) => new EmployeeMainDataDTO
                {
                    Id = COMBINED.JobTitle.Relegion.Marital.Employee.Id,
                    FullName = COMBINED.JobTitle.Relegion.Marital.Employee.FullName,
                    BrithDate = COMBINED.JobTitle.Relegion.Marital.Employee.BrithDate,
                    Nationality = COMBINED.JobTitle.Relegion.Marital.Employee.Nationality,
                    Gender = COMBINED.JobTitle.Relegion.Marital.GS.StaticValue,
                    MaritalStatus = COMBINED.JobTitle.Relegion.MS.StaticValue,
                    Relegion = COMBINED.JobTitle.RS.StaticValue,
                    Phone = COMBINED.JobTitle.Relegion.Marital.Employee.Phone,
                    Address = COMBINED.JobTitle.Relegion.Marital.Employee.Address,
                    JobTitle = COMBINED.JB.JobName,
                    Depatment = DEPT.DepartmentName,
                    Education = COMBINED.JobTitle.Relegion.Marital.Employee.Education,
                    Experience = COMBINED.JobTitle.Relegion.Marital.Employee.Experience
                }).ToListAsync();
            return data;
        }
    }
}
