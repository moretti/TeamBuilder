using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamBuilder.ViewModels
{
    public class EditTeamViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Name { get; set; }

        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
    }
}