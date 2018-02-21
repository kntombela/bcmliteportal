using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMLitePortal.Models
{
    [MetadataType(typeof(OrganisationMetaData))]
    public partial class Organisation
    {
    }

    class OrganisationMetaData
    {
        [Remote("IsOrganisationExist", "QuickStart", ErrorMessage = "Organisation already exists")]
        public string Name { get; set; }
    }
}