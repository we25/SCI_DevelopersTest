using SCLI.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Entities.Lookups
{
    [Table("Lk_JobTitle", Schema = "Lookup")]
    public class JobTitle : EntityAudit<int>
    {
        public string JobName { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department department { get; set; }
    }
}
