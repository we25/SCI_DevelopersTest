using AutoMapper;
using SCLI.Application.DTO_s.DTO_Lookups.D_Department;
using SCLI.Application.DTO_s.DTO_Lookups.D_JobTitle;
using SCLI.Application.DTO_s.DTO_Operation.D_Employee;
using SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode;
using SCLI.Domain.Entities.Lookups;
using SCLI.Domain.Entities.Operation;
using SCLI.Domain.Entities.SystemCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.ApplicationProfile
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            #region Department
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Department, DepartmentAddDTO>().ReverseMap();
            #endregion

            #region JobTitle
            CreateMap<JobTitle, JobTitleDTO>().ReverseMap();
            CreateMap<JobTitle, JobTitleAddDTO>().ReverseMap();
            #endregion

            #region Employee
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeAddDTO>().ReverseMap();
            CreateMap<Employee, EmployeeInfosDTO>().ReverseMap();
            CreateMap<Employee, EmployeeMainDataDTO>().ReverseMap();
            //CreateMap<,>().ReverseMap();
            #endregion

            #region System Code
            CreateMap<SystemCode, SystemCodeDTO>().ReverseMap();
            #endregion
        }
    }
}
