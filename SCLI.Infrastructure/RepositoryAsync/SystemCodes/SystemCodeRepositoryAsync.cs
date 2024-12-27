using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contracts.IRepository.SystemCodes;
using SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Infrastructure.RepositoryAsync.SystemCodes
{
    public class SystemCodeRepositoryAsync : ISystemCodeRepositoryAsync
    {
        SCLIAppContext appContext;
        public SystemCodeRepositoryAsync(SCLIAppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<List<SystemCodeDTO>> GetByTypeIdAsync(int TypeId)
        {
            var data = await appContext.systemCodes.Where(x => x.SystemCodeTypeId == TypeId)
                .Select(a => new SystemCodeDTO
                {
                    Id = a.Id,
                    StaticValue = a.StaticValue,
                    SystemCodeTypeId = TypeId
                }).ToListAsync();
            return data;
        }
    }
}
