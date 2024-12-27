using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCLI.Application.Contracts;
using SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode;

namespace SCLI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemCodeController : ControllerBase
    {
        ISystemCodeAppService appService;
        public SystemCodeController(ISystemCodeAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<List<SystemCodeDTO>> GetByTypeId(int TypeId)
        {
            var data = await appService.GetBySystemCodeTypeIdAsync(TypeId);
            return data;
        }
    }
}
