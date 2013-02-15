using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamBuilder.ViewModels
{
    public class IndexEmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}