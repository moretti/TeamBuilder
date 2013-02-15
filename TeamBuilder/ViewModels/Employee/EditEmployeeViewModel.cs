using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamBuilder.ViewModels
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string LastName { get; set; }

        [DisplayName("Date of birth")]
        [Required(ErrorMessage = "Required")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Team")]
        [Required(ErrorMessage = "Required")]
        public int? SelectedTeamId { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }
    }
}