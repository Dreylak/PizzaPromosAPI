using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SiteHandler : AuditableEntity
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public string HandlerUrl { get; set; }
    }
}
