using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.DTO_s.DTO_SystemCodes.D_SystemCode
{
    public class SystemCodeDTO
    {
        public int Id { get; set; }
        public string StaticValue { get; set; }
        public int SystemCodeTypeId { get; set; }
    }
}
