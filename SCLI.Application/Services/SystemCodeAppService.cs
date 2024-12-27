using AutoMapper;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts;
using SCLI.Application.Contracts.IRepository.SystemCodes;
using SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode;
using SCLI.Domain.Entities.SystemCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Services
{
    public class SystemCodeAppService : ISystemCodeAppService
    {
        IBaseRepositoryAsync<SystemCode> baseRepository;
        ISystemCodeRepositoryAsync systemCodeRepository;
        IMapper mapper;
        public SystemCodeAppService(IBaseRepositoryAsync<SystemCode> baseRepository, ISystemCodeRepositoryAsync systemCodeRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.systemCodeRepository = systemCodeRepository;
            this.mapper = mapper;
        }

        public async Task<List<SystemCodeDTO>> GetBySystemCodeTypeIdAsync(int TypeId)
        {
            var data = await systemCodeRepository.GetByTypeIdAsync(TypeId);
            return data;
        }
    }
}
