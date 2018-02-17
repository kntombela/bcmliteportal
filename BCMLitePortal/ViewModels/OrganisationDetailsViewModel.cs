using BCMLitePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCMLitePortal.ViewModels
{
    public class OrganisationDetailsViewModel
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}