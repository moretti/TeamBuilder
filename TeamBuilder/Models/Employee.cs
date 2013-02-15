using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamBuilder.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        // This tells to the EF that there is a many-to-one mapping between Employee and Team
        public Team Team { get; set; }
    }
}