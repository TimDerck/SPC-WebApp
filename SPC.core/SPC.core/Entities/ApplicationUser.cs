using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // Personal info
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Concise logging
        public string Initials { get; set; }

        // Relationships
        public Guid SiteId { get; set; }
        public virtual Site Site { get; set; }

        // Audit info
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<RawMeasurement> RawMeasurements { get; set; }

        public ICollection<UserMeasurementType> UserMeasurementTypes { get; set; }
    }
}
