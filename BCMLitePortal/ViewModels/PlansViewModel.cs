using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCMLitePortal.ViewModels
{
    public class PlansViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? Invoked { get; set; }
        public string Department { get; set; }
        public int DepartmentID { get; set; }

    }
}