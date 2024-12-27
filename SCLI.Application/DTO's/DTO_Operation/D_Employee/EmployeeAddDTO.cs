using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.DTO_s.DTO_Operation.D_Employee
{
    public class EmployeeAddDTO
    {
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public int GenderId { get; set; }
        public string Nationality { get; set; }
        public int MaritalStatusId { get; set; }
        public int RelegionId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int JobTitleId { get; set; }
        public int DepatmentId { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
    }
}
