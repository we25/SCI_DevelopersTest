using SCLI.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Entities.SystemCodes
{
    [Table("SystemCodeType", Schema = "SystemCode")]
    public class SystemCodeType : EntityBase<int>
    {
        public string Description { get; set; }
    }
}
