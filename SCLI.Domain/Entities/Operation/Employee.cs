using SCLI.Domain.Commons;
using SCLI.Domain.Entities.Lookups;
using SCLI.Domain.Entities.SystemCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Entities.Operation
{
    [Table("Op_Employee", Schema = "Operation")]
    public class Employee : EntityAudit<int>
    {
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public SystemCode genderSystemCode { get; set; }
        public string Nationality { get; set; }
        public int MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        public SystemCode statusSystemCode { get; set; }
        public int RelegionId { get; set; }
        [ForeignKey("RelegionId")]
        public SystemCode relegionSystemCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int JobTitleId { get; set; }
        [ForeignKey("JobTitleId")]
        public JobTitle jobTitle { get; set; }
        public int DepatmentId { get; set; }
        [ForeignKey("DepatmentId")]
        public Department department { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
    }
}
