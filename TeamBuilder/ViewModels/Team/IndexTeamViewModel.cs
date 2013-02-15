using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamBuilder.Models;

namespace TeamBuilder.ViewModels
{
    public class IndexTeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public IList<IndexEmployeeViewModel> Employees { get; set; }
    }
}