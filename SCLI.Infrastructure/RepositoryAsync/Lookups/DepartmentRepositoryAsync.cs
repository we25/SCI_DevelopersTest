using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contracts.IRepository.Lookups;
using SCLI.Application.DTO_s.DTO_Lookups.D_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure.RepositoryAsync.Lookups
{
    public class DepartmentRepositoryAsync : IDepartmentRepositoryAsync
    {
        SCLIAppContext appContext;
        public DepartmentRepositoryAsync(SCLIAppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<DepartmentDTO> GetByIdAsync(int Dept_Id)
        {
            var data = await appContext.departments.SingleOrDefaultAsync(x => x.Id == Dept_Id);
            if (data != null)
            {
                return new DepartmentDTO
                {
                    Id = data.Id,
                    DepartmentName = data.DepartmentName
                };
            }
            return new DepartmentDTO();
        }

        public async Task<List<DepartmentAddDTO>> GetByNameAsync(string Dept_Name)
        {
            var data = await appContext.departments.Where(x => x.DepartmentName.Contains(Dept_Name))
                .Select(a => new DepartmentAddDTO
                {
                    DepartmentName = a.DepartmentName
                }).ToListAsync();
            return data;
        }
    }
}
