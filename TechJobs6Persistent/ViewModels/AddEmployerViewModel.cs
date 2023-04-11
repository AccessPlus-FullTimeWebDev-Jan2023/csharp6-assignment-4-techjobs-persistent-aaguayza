using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage ="Name Required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Location Required")]
        public string? Location { get; set; }
    }
}
