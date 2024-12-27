﻿using SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.Contracts
{
    public interface ISystemCodeAppService
    {
        Task<List<SystemCodeDTO>> GetBySystemCodeTypeIdAsync(int TypeId);
    }
}