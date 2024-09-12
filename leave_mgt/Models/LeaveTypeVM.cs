using System.ComponentModel.DataAnnotations;

namespace leave_mgt.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Leave Name")]
        public string Name { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

    }

}
