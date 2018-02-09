using BCMLitePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCMLitePortal.ViewModels
{
    public class IncidentDateSummaryViewModel
    {
        public string Date { get; set; }
        public int Incidents { get; set; }
    }

    public class IncidentTypeSummaryViewModel
    {
        public IncidentType? Type { get; set; }
        public int Incidents { get; set; }
    }
}