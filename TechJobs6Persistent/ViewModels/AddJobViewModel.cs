using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required]
        public string? Name { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem>? Employers { get; set; }
        public AddJobViewModel(List<Employer> employers)
        {
            Employers = new List<SelectListItem>();
            foreach (var thing in employers)
            {
                Employers.Add(
                new SelectListItem
                {
                    Value = thing.Id.ToString(),
                    Text = thing.Name
                }); 
            }
        }
        public AddJobViewModel() { }
    }
}
