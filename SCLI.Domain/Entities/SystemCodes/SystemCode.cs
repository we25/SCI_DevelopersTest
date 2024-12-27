using SCLI.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Entities.SystemCodes
{
    [Table("SystemCode", Schema = "SystemCode")]
    public class SystemCode : EntityBase<int>
    {
        public string StaticValue { get; set; }
        public int SystemCodeTypeId { get; set; }
        [ForeignKey("SystemCodeTypeId")]
        public SystemCodeType systemCodeType { get; set; }
    }
}
