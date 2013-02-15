using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamBuilder.Models
{
    public class Team
    {
        // Primary key, and one-to-many relation with Employee
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}