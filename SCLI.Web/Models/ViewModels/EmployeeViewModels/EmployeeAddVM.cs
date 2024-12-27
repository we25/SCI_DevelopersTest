using System.ComponentModel.DataAnnotations;

namespace SCLI.Web.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeAddVM
    {
        [Required(ErrorMessage = "Name filed is Required !")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public DateTime brithDate { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public int genderId { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public string nationality { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public int maritalStatusId { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public int relegionId { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public string phone { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public string address { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public int jobTitleId { get; set; }

        [Required(ErrorMessage = "This filed is Required !")]
        public int depatmentId { get; set; }
        public string? education { get; set; }
        public string? experience { get; set; }
    }
}
