using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Application.DTO_s.DTO_Operation.D_Employee
{
    public class EmployeeInfosDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Relegion { get; set; }
        public string JobTitleName { get; set; }
        public string DepatmentName { get; set; }
    }
}
