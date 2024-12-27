using SCLI.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Entities.Lookups
{
    [Table("Lk_Department", Schema = "Lookup")]
    public class Department : EntityAudit<int>
    {
        public string DepartmentName { get; set; }
    }
}
