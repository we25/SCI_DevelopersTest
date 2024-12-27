using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.DTO_s.DTO_Operation.D_Employee
{
    public class EmployeeMainDataDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Relegion { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string Depatment { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
    }
}
