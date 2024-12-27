namespace SCLI.Web.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeVM
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public DateTime brithDate { get; set; }
        public int genderId { get; set; }
        public string nationality { get; set; }
        public int maritalStatusId { get; set; }
        public int relegionId { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int jobTitleId { get; set; }
        public int depatmentId { get; set; }
        public string? education { get; set; }
        public string? experience { get; set; }
    }
}
